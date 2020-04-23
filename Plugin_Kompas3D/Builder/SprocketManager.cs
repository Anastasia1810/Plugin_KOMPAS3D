using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using Parameter;


namespace Builder
{
    class SprocketManager
    {
        private SprocketBuilder _sprocketBuilder;

        private KompasObject OpenKompas3D()
        {
            KompasObject _kompasObject = null;

            try
            {
                _kompasObject.Visible = true;
                _kompasObject.ActivateControllerAPI();
            }
            catch
            {
                Type typeKompas = Type.GetTypeFromProgID("KOMPAS.Application.5");
                _kompasObject = (KompasObject)Activator.CreateInstance(typeKompas);
                _kompasObject.Visible = true;
                _kompasObject.ActivateControllerAPI();
            }
           
            return _kompasObject;
        }

        public SprocketManager(SprocketParameters parameters)
        {
            InitializeSprocket(parameters);
        }

        private void InitializeSprocket(SprocketParameters parameters)
        {
            _sprocketBuilder = new SprocketBuilder(parameters, OpenKompas3D());
        }
    }
}
