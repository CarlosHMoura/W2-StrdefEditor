 
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace W2___Strdef_Editor.Funções
{
    internal class Functions : Structs
    {
        private static byte[] pKeyList = new byte[1];

        public static BinaryType LoadFile<BinaryType>(byte[] rawData) where BinaryType : struct
        {
            GCHandle gcHandle = GCHandle.Alloc((object)rawData, GCHandleType.Pinned);
            try
            {
                return (BinaryType)Marshal.PtrToStructure(gcHandle.AddrOfPinnedObject(), typeof(BinaryType));
            }
            finally
            {
                gcHandle.Free();
            }
        }

        public static void SaveFile<BinaryType>(BinaryType Strdef)
        {
            try
            {
                byte[] numArray = new byte[Marshal.SizeOf<BinaryType>(Strdef)];
                IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf<BinaryType>(Strdef));
                Marshal.StructureToPtr<BinaryType>(Strdef, num, false);
                Marshal.Copy(num, numArray, 0, Marshal.SizeOf<BinaryType>(Strdef));
                Marshal.FreeHGlobal(num);
                byte[] array = Functions.ReadKeyList();
                Array.Resize<byte>(ref array, array.Length + 1);
                for (int index = 0; index < numArray.Length; ++index)
                    numArray[index] ^= array[index & array.Length - 1];
                File.WriteAllBytes("strdef.bin", numArray);
            }
            catch (Exception ex)
            {
                Console.WriteLine((object)ex);
            }
        }

        public static void CreateToolTipe(Control Controler, string Title, string Info)
        {
            new ToolTip()
            {
                ToolTipTitle = Title.Replace(":", ""),
                UseFading = true,
                UseAnimation = true,
                IsBalloon = true,
                ShowAlways = true,
                AutoPopDelay = 2000,
                InitialDelay = 150,
                ReshowDelay = 500
            }.SetToolTip(Controler, Info);
        }

        public static byte[] ReadKeyList()
        {
            try
            {
                if (File.Exists("./Keys.dat"))
                    return File.ReadAllBytes("./Keys.dat");
                int num = (int)MessageBox.Show("Keys.dat não foi encontrado", "W2 - Strdef Editor", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                return (byte[])null;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message + (object)Functions.pKeyList.Length);
                return (byte[])null;
            }
        }

        public static bool ReadStrdef()
        {
            try
            {
                if (File.Exists("./Strdef.bin"))
                {
                    byte[] rawData = File.ReadAllBytes("./Strdef.bin");
                    if (rawData[rawData.Length - 6] != (byte)90)
                    {
                        Functions.pKeyList = Functions.ReadKeyList();
                        Array.Resize<byte>(ref Functions.pKeyList, Functions.pKeyList.Length + 1);
                        for (int index = 0; index < rawData.Length; ++index)
                            rawData[index] ^= Functions.pKeyList[index & Functions.pKeyList.Length - 1];
                    }
                    else
                    {
                        for (int index = 0; index < rawData.Length; ++index)
                            rawData[index] ^= (byte)90;
                    }
                    External.g_pStrdef = Functions.LoadFile<Structs.STRUCT_STRDEF>(rawData);
                    return true;
                }
                int num = (int)MessageBox.Show("Strdef não foi encontrado", "W2 - Strdef Editor", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                return false;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message + (object)Functions.pKeyList.Length);
                return false;
            }
        }
    }
}