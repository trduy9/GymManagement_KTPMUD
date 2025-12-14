using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl
{
    public class GradientPanel: Panel
    {
        // Create a properties to define the colors for the gradient's top and bottom
        public Color gradientTop {get; set; }

        public Color gradientBottom { get; set; }

        // Create Constructor for the gradient panel class
        public GradientPanel()
        { 
            // Subcribe to the resize event to handle when the control's siz changes
            this.Resize += GradientPanel_Resize;
        }

        private void GradientPanel_Resize(object sender, EventArgs e)
        {
            this.Invalidate(); // this marks the control as needing to be redrawn
        }

        //override the onPaint method to draw a gradient background
        protected override void OnPaint(PaintEventArgs e)
        {
            // create a LinearGradientBrush with the specified top and bottom gradient colors

            LinearGradientBrush linear = new LinearGradientBrush(
                this.ClientRectangle, // this area to fill with the gradient
                this.gradientTop, // the starting color top of the gradient
                this.gradientBottom, // the ending color bottom of the gradient
                90F // the angle of the gradient (90 degrees for vertical)
                );

            // get the graphics context for drawing
            Graphics g = e.Graphics;

            // fill the graphics context with the gradient
            g.FillRectangle(linear, this.ClientRectangle);

            //lastly call the base class's OnPaint method to ensure any other painting is done


            base.OnPaint(e);
            // Create a LinearGradientBrush to fill the panel with a gradient
          
        }

    }
}
