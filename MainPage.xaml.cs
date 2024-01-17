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

        private void OnConvertClicked(object sender, EventArgs e)
        {
            double rSphereInput = double.Parse(RightSphere.Text);
            double rCylInput = double.Parse(RightCyl.Text);
            int rAxisInput = int.Parse(RightAxis.Text);
            double lSphereInput = double.Parse(LeftSphere.Text);
            double lCylInput = double.Parse(LeftCyl.Text);
            int lAxisInput = int.Parse(LeftAxis.Text);

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
            double rSphere = rx.rightSphere + rx.rightCyl;
            double rCyl = -1 * rx.rightCyl;
            int rAxis = (rx.rightAxis + 90) % 180;
            double lSphere = rx.leftSphere + rx.leftCyl;
            double lCyl = -1 * rx.leftCyl;
            int lAxis = (rx.leftAxis + 90) % 180;
            
            

            return new EyeRx(rSphere, rCyl, rAxis, lSphere, lCyl,lAxis);
        }

    }

}
