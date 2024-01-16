using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxConverter
{
    public class EyeRx
    {
        double rightSphere, rightCyl, leftSphere, leftCyl;
        int rightAxis, leftAxis;

        public EyeRx() { }
        public EyeRx(double rSphere, double rCyl, int rAxis,
                        double lSphere, double lCyl, int lAxis) 
        {
            this.rightSphere = rSphere;
            this.rightCyl = rCyl;
            this.rightAxis = rAxis;
            this.leftSphere = lSphere;
            this.leftCyl = lCyl;
            this.leftAxis = lAxis;
        
        }

    }
}
