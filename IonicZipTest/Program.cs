using System;
using Ionic.Zip;

namespace IonicZipTest
{
   class Program
   {
      static void doZipFile(String fileName, String zipName, String password)
      {
         using (ZipFile zip = new ZipFile())
         {
            zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
            zip.Password = password;
            zip.Encryption = EncryptionAlgorithm.WinZipAes256;
            zip.AddFile(fileName, "");
            zip.Save(zipName);
         }
      }

      static void Main(string[] args)
      {
         String fileEmpty = "../../TestFileEmpty.txt";
         String zipEmpty = "../../TestFileEmpty.zip";

         String fileFilled = "../../TestFileFilled.txt";
         String zipFilled = "../../TestFileFilled.zip";

         String password = "123456";

         // this one creates zip without encryption
         doZipFile(fileEmpty, zipEmpty, password);

         // this one works as expected
         doZipFile(fileFilled, zipFilled, password);
      }
   }
}
