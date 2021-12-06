using System;
using System.Application.Interface;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace System.Application.Application
{
    public class AAdressMAC : IAdressMAC
    {
        public string FullInfomationMAC()
        {
            string lstMAC = "";
            NetworkInterface[] lstCard = NetworkInterface.GetAllNetworkInterfaces();
            for (int i = 0; i < lstCard.Length; i++)
            {
                PhysicalAddress adressMAC = lstCard[i].GetPhysicalAddress();
                lstMAC += lstCard[i].Name + " : ";
                byte[] ByteAdress = adressMAC.GetAddressBytes();
                for (int j = 0; j < ByteAdress.Length; j++)
                {
                    lstMAC += ByteAdress[j].ToString("X2");
                    if (j != ByteAdress.Length - 1)
                    {
                        lstMAC += "-";
                    }
                }
                lstMAC += "\r\n";
                lstMAC += lstMAC;
            }
            return lstMAC;
        }
    }
}
