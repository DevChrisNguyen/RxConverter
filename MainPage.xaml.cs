using System.Threading.Tasks;
using System.Xml;

namespace RxConverter
{
    public partial class MainPage : ContentPage
    {
        EyeRx initialRx;
        EyeRx result;

        public MainPage()
        {
            InitializeComponent();
            initialRx = new EyeRx();
            result = new EyeRx();

        }

        private async void OnConvertClicked(object sender, EventArgs e)

        {
            double rSphereInput;
            double rCylInput;
            int rAxisInput;
            double lSphereInput;
            double lCylInput;
            int lAxisInput;
            
            if (RightSphere.Text == String.Empty) {
                await DisplayAlert("Alert", "Right Sphere Must be Entered! (Enter 0 for No SPH)", "Eye, eye Capt'n");
                return;
            }
            else {
                rSphereInput = double.Parse(RightSphere.Text);
                }
            if (RightCyl.Text == String.Empty)
            {
                await DisplayAlert("Alert", "Right Cyl was not Entered! (Enter 0 for No CYL)", "Eye, eye Capt'n");
                return;
            }
            else { rCylInput = double.Parse(RightCyl.Text); }
            if (RightAxis.Text == String.Empty)
            {
                await DisplayAlert("Alert", "Right Axis is missing! (Enter 0 for No Axis)", "Eye, eye Capt'n");
                return;
            }
            else {
                rAxisInput = int.Parse(RightAxis.Text);
            }
            if (LeftSphere.Text == String.Empty) { 
                await DisplayAlert("Alert", "Left Sphere Must be Entered.", "OK");
            return;
            }
            else {
                lSphereInput = double.Parse(LeftSphere.Text);
    }
            if (LeftCyl.Text == String.Empty)
            {
                await DisplayAlert("Alert", "Left Cyl Must be Entered. (Enter 0 for No Cyl", "OK");
                return;
            }
            else { lCylInput = double.Parse(LeftCyl.Text); }
            if (LeftAxis.Text == String.Empty)
            {
                await DisplayAlert("Alert", "You forgot the Left Axis! Try again.", "OK");
                return;
            }
            else
            {
                lAxisInput = int.Parse(LeftAxis.Text);
            }


            rCylInput = double.Parse(RightCyl.Text);
            rAxisInput = int.Parse(RightAxis.Text);
            lSphereInput = double.Parse(LeftSphere.Text);
            lCylInput = double.Parse(LeftCyl.Text);
            lAxisInput = int.Parse(LeftAxis.Text);

            initialRx = new EyeRx(rSphereInput, rCylInput, rAxisInput, lSphereInput, lCylInput,lAxisInput );

            result = ConvertCylinderNotation(initialRx);

            ResultSphereR.Text = result.rightSphere.ToString();
            ResultCylR.Text = result.rightCyl.ToString();
            ResultAxisR.Text = result.rightAxis.ToString();
            ResultSphereL.Text = result.leftSphere.ToString();
            ResultCylL.Text = result.leftCyl.ToString();
            ResultAxisL.Text = result.leftAxis.ToString();

        }

        EyeRx ConvertCylinderNotation(EyeRx rx)
        {
            double rSphere;
            double rCyl;
            int rAxis;
            double lSphere;
            double lCyl;
            int lAxis;


            rSphere = rx.rightSphere + rx.rightCyl;

            if (rx.rightCyl == 0) {
                rCyl = 0;
            }
            else
            {
                rCyl = -1 * rx.rightCyl;
            }
            
            rAxis = (rx.rightAxis + 90) % 180;
            if (rAxis == 0) {
                rAxis = 180; 
            }
            lSphere = rx.leftSphere + rx.leftCyl;

            if (rx.leftCyl == 0)
            {
                lCyl = 0;
            }
            else
            {
                lCyl = -1 * rx.leftCyl;
            }

            lAxis = (rx.leftAxis + 90) % 180;
            if (lAxis == 0)
            {
                lAxis = 180;
            }
            
            

            return new EyeRx(rSphere, rCyl, rAxis, lSphere, lCyl,lAxis);
        }
        private void OnClearClicked(Object sender, EventArgs e)
        {
            RightSphere.Text = string.Empty;
            RightCyl.Text = string.Empty;
            RightAxis.Text = string.Empty;
            LeftSphere.Text = string.Empty;
            LeftCyl.Text = string.Empty;
            LeftAxis.Text = string.Empty;
            ResultSphereR.Text = string.Empty;
            ResultCylR.Text = string.Empty;
            ResultAxisR.Text = string.Empty;
            ResultSphereL.Text = string.Empty;
            ResultCylL.Text = string.Empty;
            ResultAxisL.Text = string.Empty;
        }

    }

}
