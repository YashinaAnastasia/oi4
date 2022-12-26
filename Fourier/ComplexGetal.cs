using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fourier_Transformatie.Fourier {
    public class ComplexGetal {
        private float real, imagin;

        public ComplexGetal(float reëel, float imaginair) {
            this.real = reëel;
            this.imagin = imaginair;
        }

        public float Real {
            get { return real; }
            set { real = value; }
        }

        public float Imagin {
            get { return imagin; }
            set { imagin = value; }
        }

        public float Modul {
            get {
                
                return (float)(Math.Sqrt(real * real + imagin * imagin));
            }
        }

        public float Argument {
            get {
                return (float)Math.Atan2(imagin, real);
            }
        }
    }
}
