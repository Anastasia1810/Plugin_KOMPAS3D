using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using Parameter;

namespace Builder
{
    public class SprocketBuilder
    {
        private KompasObject _kompasObject;

        private SprocketParameters _sprocketParameters;

        public SprocketBuilder(SprocketParameters parameters, KompasObject kompas)
        {
            //Получение параметров звездочки
            _sprocketParameters = parameters;
            //Получение объекта KOMPAS 3D
            _kompasObject = kompas;
            //Создание звездочки
            CreateModel();
        }

        private void CreateModel()
        {
            //Получение интерфейса 3d документа
            ksDocument3D iDocument3D = (ksDocument3D)_kompasObject.Document3D();
            iDocument3D.Create(false, true);
            //Получение интерфейса детали
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
            if (_sprocketParameters.Parameter(NameParameter.CircleRadius).Value != 0 && 
                _sprocketParameters.Parameter(NameParameter.CircleThickness).Value != 0)
            {
                //Получение радиуса окружности
                var radius = _sprocketParameters.Parameter(NameParameter.CircleRadius).Value;
                //Эскиз окружности
                ksEntity iSketch = DrawCircle(iPart,radius);
                //Получение глубины выдавливания
                var height = _sprocketParameters.Parameter(NameParameter.CircleThickness).Value;
                //Выдавливание
                ExtrusionOperation(iPart, iSketch, height, false);

            }
        }

        /// <summary>
        /// Построение цилиндра
        /// </summary>
        /// <param name="iPart"></param>
        private void CreateCylinder(ksPart iPart)
        {
            //Получение глубины выдавливания
            var height = _sprocketParameters.Parameter(NameParameter.CylinderThickness).Value;
            if (height != 0)
            {
                //Получение радиуса окружности
                var radius = _sprocketParameters.Parameter(NameParameter.CylinderRadius).Value;
                //Эскиз окружности
                ksEntity iSketch = DrawCircle(iPart, radius);
                //Выдавливание
                ExtrusionOperation(iPart, iSketch, height, true);
            }
        }

        /// <summary>
        /// Построение отверстия
        /// </summary>
        /// <param name="iPart"></param>
        private void CreateHole(ksPart iPart)
        {
            //Получение радиуса окружности отверстия
            var radius = _sprocketParameters.Parameter(NameParameter.HoleRadius).Value;
            // Создаем эскиз окружности
            ksEntity entitySketch = DrawCircle(iPart, radius);
            // Создаем переменую вырезания выдавливанием
            ksEntity entityCutExtrusion = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            // Интерфейс свойств операции вырезания выдавливанием
            ksCutExtrusionDefinition cutExtrusionDefinition = (ksCutExtrusionDefinition)entityCutExtrusion.GetDefinition();
            // Устанавливаем тип направления вырезания выдавливанием
            cutExtrusionDefinition.directionType = (short)Direction_Type.dtBoth;
            //Получение длины отверстия в обратном направлении
            var topHeight = _sprocketParameters.Parameter(NameParameter.CylinderThickness).Value;
            //Устанавливаем параметры вырезания выдавливанием обратное направление на глубину
            if (topHeight != 0)
            {
                cutExtrusionDefinition.SetSideParam(false, (short)End_Type.etBlind, topHeight);
            }
            //Получение длины отверстия в прямом направлении
            var bottomHeight = _sprocketParameters.Parameter(NameParameter.CircleThickness).Value;
            // Устанавливаем параметры вырезания выдавливанием прямое направление на глубину
            cutExtrusionDefinition.SetSideParam(true, (short)End_Type.etBlind, bottomHeight);
            // Эскиз операции вырезания выдавливанием
            cutExtrusionDefinition.SetSketch(entitySketch);
            // Создаем операцию вырезания выдавливанием
            entityCutExtrusion.Create();
        }

        /// <summary>
        /// Построение шпоночной выемки
        /// </summary>
        /// <param name="iPart"></param>
        private void CreateRecess(ksPart iPart)
        {
            // Получаем интерфейс базовой плоскости ХОZ
            ksEntity planeXOY = (ksEntity)iPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
            // Создаем новый эскиз
            ksEntity iSketch = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_sketch);
            // Получаем интерфейс свойств эскиза
            ksSketchDefinition iDefinitionSketch = (ksSketchDefinition)iSketch.GetDefinition();
            // Устанавливаем плоскость эскиза
            iDefinitionSketch.SetPlane(planeXOY);
            // Создание эскиза
            iSketch.Create();
            //Задаем координаты выемки
            var minWegth = -_sprocketParameters.Parameter(NameParameter.HoleRadius).Value / 6;
            var maxWegth = _sprocketParameters.Parameter(NameParameter.HoleRadius).Value / 6;
            var minHeight = _sprocketParameters.Parameter(NameParameter.HoleRadius).Value - 1;
            var maxHeight = _sprocketParameters.Parameter(NameParameter.HoleRadius).Value + _sprocketParameters.Parameter(NameParameter.ExcavationDepth).Value;

            // Создание нового 2Д документа
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            //Построение черчежа прямоугольника(выемки)
            iDocument2D.ksLineSeg(minWegth,minHeight, maxWegth, minHeight, 1);
            iDocument2D.ksLineSeg(minWegth, minHeight, minWegth, maxHeight , 1);
            iDocument2D.ksLineSeg(minWegth,maxHeight, maxWegth, maxHeight, 1);
            iDocument2D.ksLineSeg(maxWegth, minHeight, maxWegth, maxHeight, 1);
            iDefinitionSketch.EndEdit();

            // Создаем переменую вырезания выдавливанием
            ksEntity entityCutExtrusion = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            // Интерфейс свойств операции вырезания выдавливанием
            ksCutExtrusionDefinition cutExtrusionDefinition = (ksCutExtrusionDefinition)entityCutExtrusion.GetDefinition();
            // Устанавливаем тип направления вырезания выдавливанием
            cutExtrusionDefinition.directionType = (short)Direction_Type.dtBoth;
            //Получение длины отверстия в обратном направлении
            var topHeight = _sprocketParameters.Parameter(NameParameter.CylinderThickness).Value;
            //Устанавливаем параметры вырезания выдавливанием обратное направление на глубину
            if (topHeight != 0)
            {
                cutExtrusionDefinition.SetSideParam(false, (short)End_Type.etBlind, topHeight);
            }
            //Получение длины отверстия в прямом направлении
            var bottomHeight = _sprocketParameters.Parameter(NameParameter.CircleThickness).Value;
            // Устанавливаем параметры вырезания выдавливанием прямое направление на глубину
            cutExtrusionDefinition.SetSideParam(true, (short)End_Type.etBlind, bottomHeight);
            // Эскиз операции вырезания выдавливанием
            cutExtrusionDefinition.SetSketch(iSketch);
            // Создаем операцию вырезания выдавливанием
            entityCutExtrusion.Create();
        }

        /// <summary>
        /// Построение зубьев
        /// </summary>
        /// <param name="iPart"></param>
        private void CreateTeeth(ksPart iPart)
        {
            // Создаем новый эскиз
            ksEntity entitySketch = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_sketch);
            // Интерфейс свойств эскиза
            ksSketchDefinition sketchDefinition = (ksSketchDefinition)entitySketch.GetDefinition();
            // Получаем интерфейс базовой плоскости
            ksEntity basePlane = (ksEntity)iPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
            // Устанавливаем плоскость базовой для эскиза
            sketchDefinition.SetPlane(basePlane);
            // Создаем эскиз
            entitySketch.Create();
            EllipseParam ellipseParam = (EllipseParam)_kompasObject.GetParamStruct((short)StructType2DEnum.ko_EllipseParam);
            var moreRadius = _sprocketParameters.Parameter(NameParameter.CircleRadius).Value;
            if (_sprocketParameters.Parameter(NameParameter.NumberOfTeeth).Value <= 15)
            {
                if (moreRadius < 90)
                {
                    ellipseParam.A = 9;
                    ellipseParam.B = 15;
                }
                if (moreRadius >= 90 && moreRadius < 120)
                {
                    ellipseParam.A = 12;
                    ellipseParam.B = 20;
                }
                
                if (moreRadius >= 120 && moreRadius < 180)
                {
                    ellipseParam.A = 15;
                    ellipseParam.B = 25;
                }

                if (moreRadius >= 180 && moreRadius < 240)
                {
                    ellipseParam.A = 18;
                    ellipseParam.B = 35;
                }

                if (moreRadius >= 240)
                {
                    ellipseParam.A = 21;
                    ellipseParam.B = 40;
                }
            }
            else 
            {
                if (_sprocketParameters.Parameter(NameParameter.NumberOfTeeth).Value >= 23)
                {
                    if (moreRadius < 90)
                    {
                        ellipseParam.A = 4;
                        ellipseParam.B = 10;
                    }
                    if (moreRadius >= 90 && moreRadius < 120)
                    {
                        ellipseParam.A = 6;
                        ellipseParam.B = 20;
                    }

                    if (moreRadius >= 120 && moreRadius < 180)
                    {
                        ellipseParam.A = 9;
                        ellipseParam.B = 25;
                    }

                    if (moreRadius >= 180 && moreRadius < 240)
                    {
                        ellipseParam.A = 12;
                        ellipseParam.B = 35;
                    }

                    if (moreRadius >= 240)
                    {
                        ellipseParam.A = 15;
                        ellipseParam.B = 40;
                    }
                }
                else
                {
                    if (moreRadius < 90)
                    {
                        ellipseParam.A = 6;
                        ellipseParam.B = 10;
                    }
                    if (moreRadius >= 90 && moreRadius < 120)
                    {
                        ellipseParam.A = 9;
                        ellipseParam.B = 20;
                    }

                    if (moreRadius >= 120 && moreRadius < 180)
                    {
                        ellipseParam.A = 12;
                        ellipseParam.B = 25;
                    }

                    if (moreRadius >= 180 && moreRadius < 240)
                    {
                        ellipseParam.A = 15;
                        ellipseParam.B = 35;
                    }

                    if (moreRadius >= 240)
                    {
                        ellipseParam.A = 18;
                        ellipseParam.B = 40;
                    }
                }
            }
            ellipseParam.xc = 0;
            ellipseParam.yc = moreRadius;
            ellipseParam.angle = 0;
            ellipseParam.style = 1;
            // Интерфейс редактора эскиза
            ksDocument2D sketchEdit = (ksDocument2D)sketchDefinition.BeginEdit();
            sketchEdit.ksEllipse(ellipseParam);
            // Завершаем редактирование эскиза
            sketchDefinition.EndEdit();

            // Создаем переменую вырезания выдавливанием
            ksEntity entityCutExtrusion = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            // Интерфейс свойств операции вырезания выдавливанием
            ksCutExtrusionDefinition cutExtrusionDefinition = (ksCutExtrusionDefinition)entityCutExtrusion.GetDefinition();
            // Устанавливаем тип направления вырезания выдавливанием
            cutExtrusionDefinition.directionType = (short)Direction_Type.dtNormal;
            //Получение длины отверстия в прямом направлении
            var height = _sprocketParameters.Parameter(NameParameter.CircleThickness).Value;
            // Устанавливаем параметры вырезания выдавливанием
            cutExtrusionDefinition.SetSideParam(true, // Прямое направление
                                    (short)End_Type.etBlind,
                                    height); // Строго на глубину
            // Эскиз операции вырезания выдавливанием
            cutExtrusionDefinition.SetSketch(entitySketch);
            // Создаем операцию вырезания выдавливанием
            entityCutExtrusion.Create();

            // Создаем переменную копирования по концентрическрй сетке
            ksEntity circularCopyEntity = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_circularCopy);
            // Интерфейс свойств операции копирования по концентрической сетке
            ksCircularCopyDefinition circularCopyDefinition = (ksCircularCopyDefinition)circularCopyEntity.GetDefinition();
            var number = _sprocketParameters.Parameter(NameParameter.NumberOfTeeth).Value;
            int count = Convert.ToInt32(number);
            // Устанавливаем параметры копирования
            circularCopyDefinition.SetCopyParamAlongDir(count, 360.0, true, false);
            // Получаем интерфейс оси копирования
            ksEntity baseAxisOY = (ksEntity)iPart.GetDefaultEntity((short)Obj3dType.o3d_axisOY);
            // Устанавливаем ось копирования
            circularCopyDefinition.SetAxis(baseAxisOY);
            // Интерфейс массива объектов модели
            ksEntityCollection entityCollection = (ksEntityCollection)circularCopyDefinition.GetOperationArray();
            entityCollection.Add(cutExtrusionDefinition);
            // Создаем операцию копирования по концентрической сетке
            circularCopyEntity.Create();
        }




            
        private ksEntity DrawCircle(ksPart iPart, double radius)
        {

            //Получаем интерфейс базовой плоскости ХОY
            ksEntity planeZOY =
                (ksEntity)iPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
            //Создаем новый эскиз
            ksEntity iSketch =
                (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_sketch);
            //Получаем интерфейс свойств эскиза
            ksSketchDefinition iDefinitionSketch = (ksSketchDefinition)iSketch.GetDefinition();
            //Устанавливаем плоскость эскиза
            iDefinitionSketch.SetPlane(planeZOY);
            //Создание эскиза
            iSketch.Create();
            //Создание нового 2Д документа
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            //Получение радиуса рукояти
            //Построение круга
            iDocument2D.ksCircle(0, 0, radius, 1);
            //Создание эскиза
            iDefinitionSketch.EndEdit();
            return iSketch;
        }
        private void ExtrusionOperation(ksPart part, ksEntity sketch, double height, bool type)
        {
            // Создаем переменную выдавливания
            ksEntity entityExtrusion = (ksEntity)part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            // Интерфейс свойств базовой операции выдавливания
            ksBossExtrusionDefinition extrusionDefinition = (ksBossExtrusionDefinition)entityExtrusion.GetDefinition();
            if (type == false)
            {
                // Устанавливаем тип направления выдавливания
                extrusionDefinition.directionType = (short)Direction_Type.dtReverse; //Обратное направление
                // Устанавливаем параметры выдавливания
                extrusionDefinition.SetSideParam(false, // Обратное направление
                                          (short)End_Type.etBlind, // Строго на глубину
                                          height); // Расстояние выдавливания
            }
            if (type == true)
            {
                // Устанавливаем тип направления выдавливания
                extrusionDefinition.directionType = (short)Direction_Type.dtNormal; //Прямое направление
                // Устанавливаем параметры выдавливания
                extrusionDefinition.SetSideParam(true, // Прямое направление
                                          (short)End_Type.etBlind, // Строго на глубину
                                          height); // Расстояние выдавливания
            }
            //Эскиз операции выдавливания
            extrusionDefinition.SetSketch(sketch);
            // Создаем операцию выдавливания
            entityExtrusion.Create();
        }
    }
}
