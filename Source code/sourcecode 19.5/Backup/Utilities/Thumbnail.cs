using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using Logger;

namespace Utilities
{
    public class Thumbnail
    {

        //string ThumbFolderPath = "~/resource/thumb/";
        public bool GenerateThumbnail(string fileName,string sourcedes,string filedes,int maxwidth)
        {
            double tile=0;
            int shtWidth=0;
            int shtHeight=0;
            try
            {
                //Get The Image From File
                Image OriginalImage = Image.FromFile(HttpContext.Current.Server.MapPath(sourcedes + fileName));
                if (OriginalImage.Width >= OriginalImage.Height)
                {
                    tile = OriginalImage.Width/(double)OriginalImage.Height;
                    if (OriginalImage.Width > maxwidth)
                    {
                        shtWidth = maxwidth;
                    }
                    else
                    {
                        shtWidth = OriginalImage.Width;
                    }
                    
                    shtHeight =Convert.ToInt32(shtWidth/tile);
                    
                }
                else
                {
                    tile = OriginalImage.Height / (double)OriginalImage.Width;
                    if (OriginalImage.Width > maxwidth)
                      shtWidth = maxwidth;
                    else
                        shtWidth = OriginalImage.Width;
                    shtHeight =Convert.ToInt32(shtWidth*tile);
                }

                //OriginalImage.Save(HttpContext.Current.Server.MapPath(sourcedes + filedes));
                
                //Create ITs Thumbnail
                Image ThumbImage = OriginalImage.GetThumbnailImage(shtWidth, shtHeight, null, new IntPtr());
                
                //Store It in Thumbnail Folder
                
                ThumbImage.Save(HttpContext.Current.Server.MapPath(sourcedes + filedes));
                ThumbImage.Dispose();
                //ThumbImage.Save(HttpContext.Current.Server.MapPath(sourcedes + filedes), ImageFormat.Gif);

                return true;
            }
            catch(Exception ex)
            {
                Log.info("Exception GenerateThumbnail :" + ex.Message);
                return false;
            }
        }
        private bool saveImageAs(string fileName, string sourcedes, string filedes)
        {
            try
            {
                //Get The Image From File
                Image OriginalImage = Image.FromFile(HttpContext.Current.Server.MapPath(sourcedes + fileName));
                OriginalImage.Save(HttpContext.Current.Server.MapPath(sourcedes + filedes));
                return true;
            }
            catch (Exception ex)
            {
                Log.info("Exception saveImageAs :" + ex.Message);
                return false;
            }
        }
        public bool getGenerateThumbnail(string fileName, string sourcedes, int maxwidth)
        {
            double tile = 0;
            int shtWidth = 0;
            int shtHeight = 0;
            try
            {
                //Get The Image From File
                Image OriginalImage = Image.FromFile(HttpContext.Current.Server.MapPath(sourcedes + fileName));
                if (OriginalImage.Width >= OriginalImage.Height)
                {
                    tile = OriginalImage.Width / (double)OriginalImage.Height;
                    if (OriginalImage.Width > maxwidth)
                    {
                        shtWidth = maxwidth;
                    }
                    else
                    {
                        shtWidth = OriginalImage.Width;
                    }

                    shtHeight = Convert.ToInt32(shtWidth / tile);

                }
                else
                {
                    tile = OriginalImage.Height / (double)OriginalImage.Width;
                    if (OriginalImage.Width > maxwidth)
                        shtWidth = maxwidth;
                    else
                        shtWidth = OriginalImage.Width;
                    shtHeight = Convert.ToInt32(shtWidth * tile);
                }

                
                Bitmap bitmap = new Bitmap(shtWidth, shtHeight);
                Graphics.FromImage(bitmap).DrawImage(OriginalImage, 0, 0, shtWidth, shtHeight);
                OriginalImage.Dispose();
                bitmap.Save(HttpContext.Current.Server.MapPath(sourcedes + fileName));
                bitmap.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                Log.info("Exception getGenerateThumbnail :" + ex.Message);
                return false;
            }
        }
        public bool ResizeImage(string strResourceFile, int intHeight, int intWidth)
        {
            Image image = Image.FromFile(strResourceFile);
            if ((image.Height > intHeight) || (image.Width > intWidth))
            {
                float num = ((float)image.Height) / ((float)intHeight);
                float num2 = ((float)image.Width) / ((float)intWidth);
                int height = Math.Min(intHeight, image.Height);
                int width = (image.Width * height) / image.Height;
                if (num < num2)
                {
                    width = Math.Min(intWidth, image.Width);
                    height = (image.Height * width) / image.Width;
                }
                Bitmap bitmap = new Bitmap(width, height);
                Graphics.FromImage(bitmap).DrawImage(image, 0, 0, width, height);
                image.Dispose();
                bitmap.Save(strResourceFile);
                bitmap.Dispose();
            }
            return true;
        }
    }
}
