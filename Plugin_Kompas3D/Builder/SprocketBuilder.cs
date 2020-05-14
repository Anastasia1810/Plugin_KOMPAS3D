using System;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using ModelParameter;

namespace Builder
{
    /// <summary>
    /// Класс для построения 3D звездочки в КОМПАС-3D
    /// </summary>
    public class SprocketBuilder
    {
        /// <summary>
        /// Хранит ссылку на экземпляр объектра КОМПАС-3D
        /// </summary>
        private KompasObject _kompasObject;

        /// <summary>
        /// Хранит параметры звездочки
        /// </summary>
        private SprocketParameters _sprocketParameters;

        /// <summary>
        /// Конструктор класса SprocketBuilder
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="kompas"></param>
        public SprocketBuilder(SprocketParameters parameters, KompasObject kompas)
        {
            _sprocketParameters = parameters;
            _kompasObject = kompas;
            CreateModel();       
        }

        /// <summary>
        /// Построение 3D звездочки
        /// </summary>
        private void CreateModel()
        {
            ksDocument3D iDocument3D = (ksDocument3D)_kompasObject.Document3D();
            iDocument3D.Create(false, true);
            ksPart iPart = (ksPart)iDocument3D.GetPart((short)Part_Type.pTop_Part);
            //Создание внешней окружности
            CreateCircle(iPart);
            //Создание цилиндра
            CreateCylinder(iPart);
            //Создание отверстия
            CreateHole(iPart);
            //Создание шпоночной выемки
            CreateRecess(iPart);
            //Создание зубьев
            CreateTeeth(iPart);
        }

        /// <summary>
        /// Построение внешней окружности
        /// </summary>
        /// <param name="iPart"></param>
        private void CreateCircle(ksPart iPart)
        {
            var radius = _sprocketParameters.Parameter(NameParameter.CircleRadius).Value;
            ksEntity iSketch = DrawCircle(iPart,radius);
            var height = _sprocketParameters.Parameter(NameParameter.CircleThickness).Value;
            ExtrusionOperation(iPart, iSketch, height, false);

        }

        /// <summary>
        /// Построение цилиндра
        /// </summary>
        /// <param name="iPart"></param>
        private void CreateCylinder(ksPart iPart)
        {
            var height = _sprocketParameters.Parameter(NameParameter.CylinderThickness).Value;
            if (height != 0)
            {
                var radius = _sprocketParameters.Parameter(NameParameter.CylinderRadius).Value;
                ksEntity iSketch = DrawCircle(iPart, radius);
                ExtrusionOperation(iPart, iSketch, height, true);
            }
        }

        /// <summary>
        /// Построение отверстия
        /// </summary>
        /// <param name="iPart"></param>
        private void CreateHole(ksPart iPart)
        {
            var radius = _sprocketParameters.Parameter(NameParameter.HoleRadius).Value;
            ksEntity iSketch = DrawCircle(iPart, radius);
            var topHeight = _sprocketParameters.Parameter(NameParameter.CylinderThickness).Value;
            var bottomHeight = _sprocketParameters.Parameter(NameParameter.CircleThickness).Value;
            CutExtrusion(iPart, iSketch, topHeight, bottomHeight);
        }


        /// <summary>
        /// Построение шпоночной выемки
        /// </summary>
        /// <param name="iPart"></param>
        private void CreateRecess(ksPart iPart)
        {
            ksEntity planeXOZ = (ksEntity)iPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
            ksEntity iSketch = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition iDefinitionSketch = (ksSketchDefinition)iSketch.GetDefinition();
            iDefinitionSketch.SetPlane(planeXOZ);
            iSketch.Create();

            //Задаем координаты выемки
            var minWegth = -_sprocketParameters.Parameter(NameParameter.HoleRadius).Value / 6;
            var maxWegth = _sprocketParameters.Parameter(NameParameter.HoleRadius).Value / 6;
            var minHeight = _sprocketParameters.Parameter(NameParameter.HoleRadius).Value - 1;
            var maxHeight = _sprocketParameters.Parameter(NameParameter.HoleRadius).Value + _sprocketParameters.Parameter(NameParameter.ExcavationDepth).Value;

            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();

            //Построение черчежа прямоугольника(выемки)
            iDocument2D.ksLineSeg(minWegth,minHeight, maxWegth, minHeight, 1);
            iDocument2D.ksLineSeg(minWegth, minHeight, minWegth, maxHeight , 1);
            iDocument2D.ksLineSeg(minWegth,maxHeight, maxWegth, maxHeight, 1);
            iDocument2D.ksLineSeg(maxWegth, minHeight, maxWegth, maxHeight, 1);
            iDefinitionSketch.EndEdit();
            var topHeight = _sprocketParameters.Parameter(NameParameter.CylinderThickness).Value;
            var bottomHeight = _sprocketParameters.Parameter(NameParameter.CircleThickness).Value;

            CutExtrusion(iPart, iSketch, topHeight, bottomHeight);

        }
      
        /// <summary>
        /// Построение зубьев
        /// </summary>
        /// <param name="iPart"></param>
        private void CreateTeeth(ksPart iPart)
        {
            ksEntity entitySketch = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition sketchDefinition = (ksSketchDefinition)entitySketch.GetDefinition();
            ksEntity planeXOZ = (ksEntity)iPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
            sketchDefinition.SetPlane(planeXOZ);
            entitySketch.Create();
            EllipseParam ellipseParam = 
                (EllipseParam)_kompasObject.GetParamStruct((short)StructType2DEnum.ko_EllipseParam);
             var moreRadius = _sprocketParameters.Parameter(NameParameter.CircleRadius).Value;
            //Проверяем условия, сколько задано зубьев, из этого устанавливаем размер
            //полуоси A эллипса
            if (_sprocketParameters.Parameter(NameParameter.NumberOfTeeth).Value <= 15)
            {
                if (moreRadius < 90)
                {
                    ellipseParam.A = 9;
                }
                if (moreRadius >= 90 && moreRadius < 120)
                {
                    ellipseParam.A = 12;
                }
                
                if (moreRadius >= 120 && moreRadius < 180)
                {
                    ellipseParam.A = 15;
                }

                if (moreRadius >= 180 && moreRadius < 240)
                {
                    ellipseParam.A = 18;
                }

                if (moreRadius >= 240)
                {
                    ellipseParam.A = 21;
                }
            }
            else 
            {
                if (_sprocketParameters.Parameter(NameParameter.NumberOfTeeth).Value >= 23)
                {
                    if (moreRadius < 90)
                    {
                        ellipseParam.A = 4;
                    }
                    if (moreRadius >= 90 && moreRadius < 120)
                    {
                        ellipseParam.A = 6;
                    }

                    if (moreRadius >= 120 && moreRadius < 180)
                    {
                        ellipseParam.A = 9;
                    }

                    if (moreRadius >= 180 && moreRadius < 240)
                    {
                        ellipseParam.A = 12;
                    }

                    if (moreRadius >= 240)
                    {
                        ellipseParam.A = 17;
                    }
                }
                else
                {
                    if (moreRadius < 90)
                    {
                        ellipseParam.A = 6;
                    }
                    if (moreRadius >= 90 && moreRadius < 120)
                    {
                        ellipseParam.A = 9;
                    }

                    if (moreRadius >= 120 && moreRadius < 180)
                    {
                        ellipseParam.A = 12;
                    }

                    if (moreRadius >= 180 && moreRadius < 240)
                    {
                        ellipseParam.A = 15;
                    }

                    if (moreRadius >= 240)
                    {
                        ellipseParam.A = 19;
                    }
                }
            }
            ellipseParam.B = _sprocketParameters.Parameter(NameParameter.ToothDepht).Value;
            ellipseParam.xc = 0;
            ellipseParam.yc = moreRadius;
            ellipseParam.angle = 0;
            ellipseParam.style = 1;
            ksDocument2D iDocument2D = (ksDocument2D)sketchDefinition.BeginEdit();
            iDocument2D.ksEllipse(ellipseParam);
            sketchDefinition.EndEdit();

            ksEntity entityCutExtrusion = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition cutExtrusionDefinition = 
                (ksCutExtrusionDefinition)entityCutExtrusion.GetDefinition();
            cutExtrusionDefinition.directionType = (short)Direction_Type.dtNormal;
            var height = _sprocketParameters.Parameter(NameParameter.CircleThickness).Value;
            cutExtrusionDefinition.SetSideParam(true, (short)End_Type.etBlind, height);
            cutExtrusionDefinition.SetSketch(entitySketch);
            entityCutExtrusion.Create();

            ksEntity circularCopyEntity = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_circularCopy);
            ksCircularCopyDefinition circularCopyDefinition = 
                (ksCircularCopyDefinition)circularCopyEntity.GetDefinition();
            var number = _sprocketParameters.Parameter(NameParameter.NumberOfTeeth).Value;
            int count = Convert.ToInt32(number);
            circularCopyDefinition.SetCopyParamAlongDir(count, 360.0, true, false);
            ksEntity baseAxisOY = (ksEntity)iPart.GetDefaultEntity((short)Obj3dType.o3d_axisOY);
            circularCopyDefinition.SetAxis(baseAxisOY);
            ksEntityCollection entityCollection = 
                (ksEntityCollection)circularCopyDefinition.GetOperationArray();
            entityCollection.Add(cutExtrusionDefinition);
            circularCopyEntity.Create();
        }
      
        /// <summary>
        /// Метод для создания и возвращения эскиза окружности с заданным радиусом
        /// </summary>
        /// <param name="iPart"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        private ksEntity DrawCircle(ksPart iPart, double radius)
        {
            ksEntity planeXOZ = (ksEntity)iPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
            ksEntity iSketch = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition iDefinitionSketch = (ksSketchDefinition)iSketch.GetDefinition();
            iDefinitionSketch.SetPlane(planeXOZ);
            iSketch.Create();
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            iDocument2D.ksCircle(0, 0, radius, 1);
            iDefinitionSketch.EndEdit();
            return iSketch;
        }
        /// <summary>
        /// Метод выполнения выдавливания по эскизу
        /// </summary>
        /// <param name="part"></param>
        /// <param name="sketch"></param>
        /// <param name="height"></param>
        /// <param name="type"></param>
        private void ExtrusionOperation(ksPart part, ksEntity sketch, double height, bool type)
        {
            ksEntity entityExtrusion = (ksEntity)part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            ksBossExtrusionDefinition extrusionDefinition = 
                (ksBossExtrusionDefinition)entityExtrusion.GetDefinition();
            if (type == false)
            {
                extrusionDefinition.directionType = (short)Direction_Type.dtReverse; 
                extrusionDefinition.SetSideParam(false, (short)End_Type.etBlind, height); 
            }
            if (type == true)
            {
                extrusionDefinition.directionType = (short)Direction_Type.dtNormal; 
                extrusionDefinition.SetSideParam(true, (short)End_Type.etBlind, height); 
            }
            extrusionDefinition.SetSketch(sketch);
            entityExtrusion.Create();
        }

        /// <summary>
        /// Метод вырезания выдавливанием по эскизу
        /// </summary>
        /// <param name="iPart"></param>
        /// <param name="iSketch"></param>
        /// <param name="topHeight"></param>
        /// <param name="bottomHeight"></param>
        private void CutExtrusion(ksPart iPart, ksEntity iSketch, double topHeight, double bottomHeight)
        {
            ksEntity entityCutExtrusion = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition cutExtrusionDefinition =
                (ksCutExtrusionDefinition)entityCutExtrusion.GetDefinition();
            cutExtrusionDefinition.directionType = (short)Direction_Type.dtBoth;

            if (topHeight != 0)
            {
                cutExtrusionDefinition.SetSideParam(false, (short)End_Type.etBlind, topHeight);
            }

            cutExtrusionDefinition.SetSideParam(true, (short)End_Type.etBlind, bottomHeight);
            cutExtrusionDefinition.SetSketch(iSketch);
            entityCutExtrusion.Create();
        }
    }
}
