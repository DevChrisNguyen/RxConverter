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
            double rSphereInput = Double.Parse(RightSphere.Text);
            double rCylInput = Double.Parse(RightCyl.Text);
            int rAxisInput = Int32.Parse(RightAxis.Text);
            double lSphereInput = Double.Parse(LeftSphere.Text);
            double lCylInput = Double.Parse(LeftCyl.Text);
            int lAxisInput = Int32.Parse(LeftAxis.Text);

            initialRx = new EyeRx(rSphereInput, rCylInput, rAxisInput, lSphereInput, lCylInput,lAxisInput );

            result = ConvertCylinderNotation(initialRx);

            ResultSphereR.Text = "Something else";


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
