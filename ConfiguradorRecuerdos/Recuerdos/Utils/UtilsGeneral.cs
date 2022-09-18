using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Recuerdos.Utils
{
    class UtilsGeneral
    {
        

        public static string generarMD5(string rutaFichero) {
            using (var md5 = MD5.Create()) {
                using (FileStream stream = File.OpenRead(rutaFichero)) {
                    byte[] fileBytes = new byte[50000];
                    stream.Read(fileBytes, 0, 50000);
                    byte[] hash = md5.ComputeHash(fileBytes);
                    string md5String = Encoding.Unicode.GetString(hash);
                    return md5String;
                }
            }
        }
    }
}
