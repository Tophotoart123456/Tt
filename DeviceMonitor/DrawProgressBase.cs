using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace DeviceMonitor
{
    class DrawProgressBase
    {
        BufferedGraphicsContext BufferedGraphicsContext = null;
        BufferedGraphics bufferedGraphics = null;
        public DrawProgressBase()
        {
            BufferedGraphicsContext=BufferedGraphicsManager.Current;
        }
        public void InitGdiResource(Graphics g,Rectangle rg)
        {
            bufferedGraphics = BufferedGraphicsContext.Allocate(g,rg);
        }

    }
}
