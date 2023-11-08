namespace Aspose.TeX.Examples.CSharp.TeXTypesetting
{
    class SetMeteredLicense
    {
        public static void Run()
        {
            // ExStart:SetMeteredLicense
            // Set metered public and private keys.
            new Aspose.TeX.Metered().SetMeteredKey(
                "<type public key here>",
                "<type private key here>");
            // ExEnd:SetMeteredLicense
        }
    }
}
