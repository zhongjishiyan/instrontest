using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CircularIndeterminateProgress
    {

    // *************************** class CircularIndeterminateProgress
    
    public partial class CircularIndeterminateProgress : UserControl
        {

        public enum             INDICATORTYPES { ANIMATED, PULSED };

        const int               MAXIMUM_CIRCLES_COUNT = 10;
        const int               MINIMUM_CIRCLES_COUNT = 5;
        const int               DEFAULT_CIRCLES_COUNT = 5;

        const int               MAXIMUM_CONTROL_WIDTH_HEIGHT = 400;
        const int               MINIMUM_CONTROL_WIDTH_HEIGHT = 20;
        const int               DEFAULT_CONTROL_WIDTH_HEIGHT = 30;

        const int               MAXIMUM_INDICATOR_DIAMETER = 100;
        const int               MINIMUM_INDICATOR_DIAMETER = 4;
        const int               DEFAULT_INDICATOR_DIAMETER = 8;

        const int               MAXIMUM_REFRESH_RATE = 300;
        const int               MINIMUM_REFRESH_RATE = 50;
        const int               DEFAULT_REFRESH_RATE = 100;
        
        private Color           background_color = 
                                    SystemColors.Control;
        private int             circles_count = DEFAULT_CIRCLES_COUNT;
        private Color           control_color = SystemColors.Control;
        private GraphicsBuffer  control_graphic = null;
        private int             control_width_height = 
                                    DEFAULT_CONTROL_WIDTH_HEIGHT;
        private float           indicator_angle = 0.0F;
        private float           indicator_angular_advance = 0.7F;
        private Color           indicator_color = Color.Black;
        private int             indicator_diameter = 
                                    DEFAULT_INDICATOR_DIAMETER;
        private GraphicsBuffer  indicator_graphic = null;
        private INDICATORTYPES  indicator_type = 
                                    INDICATORTYPES.ANIMATED;
        private float           phi;
        private float           R;
        private float           r;
        private int             refresh_rate = DEFAULT_REFRESH_RATE;
        private float           theta;
        private Timer           timer;
        
        // ********************************* update_indicator_geometry
        
        /// <summary>
        /// phi is one-half the angle subtended by one indicator 
        /// circle as measured from the center of the control; phi is 
        /// dependent upon the control and indicator diameters; theta 
        /// is two times phi and is the angular shift from center to 
        /// center of two adjacent indicator circles
        /// 
        /// the centers of the indicator circle are at 
        ///     ( R, phi + i * theta ) | i = 0, n; 
        ///                              n = number of circles
        /// 
        /// invoke this method when ever the indicator diameter or the 
        /// control width/height are changed
        /// </summary>
        /// <remarks>
        /// note that phi is negative because when drawing the 
        /// indicator circles, we move counterclockwise; likewise
        /// because the indicator moves clockwise, we must flip the 
        /// sign of theta
        /// </remarks>
        void update_indicator_geometry ( )
            {

            r = ( float ) IndicatorDiameter / 2.0F;
            R = ( ( float ) ControlWidthHeight / 2.0F ) - r;
            phi = -( float ) Math.Atan2 ( ( double ) r, 
                                          ( double ) R );
            theta = 2.0F * phi;
            indicator_angular_advance = -theta;
            }
            
        // ********************************************* lighter_color
        
        // http://stackoverflow.com/questions/801406/
        //     c-create-a-lighter-darker-color-based-on-a-system-color

        Color lighter_color ( Color  color,
                              float  factor )
            {
            Color  new_color = Color.Black;
            
            try
                {
                float red = ( 255 - color.R ) * factor + color.R;
                float green = ( 255 - color.G ) * factor + color.G;
                float blue = ( 255 - color.B ) * factor + color.B;

                new_color = Color.FromArgb ( color.A, 
                                             ( int ) red, 
                                             ( int ) green, 
                                             ( int ) blue );
                }
            catch ( Exception ex )
                {
                new_color = Color.Black;
                }
            
            return ( new_color );
            }
            
        // ****************************** memory_cleanup event handler

        private void memory_cleanup ( object    sender,
                                      EventArgs e )
            {

            if ( control_graphic != null )
                {
                control_graphic =
                    control_graphic.DeleteGraphicsBuffer ( );
                }

            if ( indicator_graphic != null )
                {
                indicator_graphic =
                    indicator_graphic.DeleteGraphicsBuffer ( );
                }
            }

        // ***************************** CircularIndeterminateProgress
        
        public CircularIndeterminateProgress ( )
            {
            
            //InitializeComponent ( );
            
            Application.ApplicationExit += new EventHandler ( 
                                                   memory_cleanup );
            memory_cleanup ( this, EventArgs.Empty );
                                        // order important
            indicator_diameter = DEFAULT_INDICATOR_DIAMETER;
            control_width_height = DEFAULT_CONTROL_WIDTH_HEIGHT;
            update_indicator_geometry ( );

            this.Width = ControlWidthHeight;
            this.Height = this.Width;

            background_color = SystemColors.Control;
            circles_count = DEFAULT_CIRCLES_COUNT;
            control_color = SystemColors.Control;
            indicator_angle = 0.0F;
            indicator_color = Color.Black;
            indicator_type = INDICATORTYPES.ANIMATED;
            refresh_rate = DEFAULT_REFRESH_RATE;
                                        // order important here!!
            this.SetStyle ( ( ControlStyles.DoubleBuffer |
                              ControlStyles.UserPaint |
                              ControlStyles.AllPaintingInWmPaint ),
                            true );
            this.UpdateStyles ( );

            timer = new Timer ( );
            timer.Interval = refresh_rate;
            timer.Tick += new EventHandler ( Pulse );
            timer.Start ( );
            timer.Enabled = true;
            }
            
        // ************************************ create_control_graphic

        /// <summary>
        /// deletes any existing control graphic and then creates a 
        /// new one
        /// </summary>
        void create_control_graphic ( )
            {
            Rectangle   bounding_rectangle;

            if ( control_graphic != null )
                {
                control_graphic =
                    control_graphic.DeleteGraphicsBuffer ( );
                }

            control_graphic = new GraphicsBuffer ( );

            if ( control_graphic.CreateGraphicsBuffer (
                            this.CreateGraphics ( ),
                            ControlWidthHeight,
                            ControlWidthHeight ) )
                {
                control_graphic.g.SmoothingMode =
                                  SmoothingMode.HighQuality;
                bounding_rectangle = this.ClientRectangle;
                bounding_rectangle.Inflate ( 1, 1 );
                control_graphic.g.FillRectangle (
                    new SolidBrush ( BackgroundColor ),
                    bounding_rectangle );
                bounding_rectangle.Inflate ( -1, -1 );
                }
            }

        // **************************************** polar_to_cartesian
        
        // http://en.wikipedia.org/wiki/Polar_coordinate_system
        
        public void polar_to_cartesian (     float  radius,
                                             float  theta,  // radians
                                         out int    x,
                                         out int    y )
            {
            double  r = ( double ) radius;
            double  t = ( double ) theta;
            
            x = ( int ) ( r * Math.Cos ( t ) );
            y = ( int ) ( r * Math.Sin ( t ) );
            }
            
        // ********************************** create_indicator_graphic

        /// <summary>
        /// this method creates a new indicator graphic that is the 
        /// size of the control graphic; it rotates clockwise around 
        /// the center of the control graphic; the indicator graphic 
        /// initially has its leading edge at the x-axis; any existing 
        /// indicator graphic will be deleted
        /// </summary>
        void create_indicator_graphic ( )
            {
            try
            {
                // effectively erases the 
                // background
                if (control_graphic == null)
                {
                    create_control_graphic();
                }

                if (indicator_graphic != null)
                {
                    indicator_graphic =
                        indicator_graphic.DeleteGraphicsBuffer();
                }

                indicator_graphic = new GraphicsBuffer();

                update_indicator_geometry();

                if (indicator_graphic.CreateGraphicsBuffer(
                                this.CreateGraphics(),
                                ControlWidthHeight,
                                ControlWidthHeight))
                {
                    Color color = IndicatorColor;
                    Graphics graphics = indicator_graphic.g;
                    Rectangle indicator_bounding_rectangle;
                    Size size = new Size((int)(2.0F * r),
                                                  (int)(2.0F * r));

                    indicator_graphic.g.SmoothingMode =
                                      SmoothingMode.HighQuality;
                    indicator_bounding_rectangle = this.ClientRectangle;
                    indicator_graphic.g.FillRectangle(
                        new SolidBrush(Color.Transparent),
                        indicator_bounding_rectangle);
                    for (int i = 0; (i < CirclesCount); i++)
                    {
                        float angle;
                        Rectangle bounding_rectangle;
                        Brush brush = new SolidBrush(color);
                        Point top_left = new Point();
                        int x;
                        int y;

                        angle = (phi + (float)i * theta) +
                                indicator_angle;
                        polar_to_cartesian(R,
                                                 angle,
                                             out x,
                                             out y);
                        top_left.X = (int)((float)x - r) +
                                     this.Width / 2;
                        top_left.Y = (int)((float)y - r) +
                                     this.Height / 2;

                        bounding_rectangle = new Rectangle(top_left,
                                                             size);
                        graphics.FillEllipse(brush,
                                               bounding_rectangle);

                        brush.Dispose();

                        color = lighter_color(color, 0.25F);
                    }
                }
            }
            catch (Exception e1)
            {

            }
            }

        // *************************************** Pulse event handler

        /// <summary>
        /// Pulse is overloaded to allow it to be used as both an 
        /// event handler (with parameters) and as a method (without
        /// parameters)
        /// </summary>
        public void Pulse ( object      sender,
                            EventArgs   e )
            {

            this.UpdateStyles ( );
            this.Invalidate ( );
            }

        // ********************************************** Pulse method

        public void Pulse ( )
            {

            this.UpdateStyles ( );
            this.Invalidate ( );
            }

        // *************************************************** Animate

        [Category ( "CircularIndeterminateProgress" ),
         Description ( "Start/stops indicator animation" ),
         DefaultValue ( true ),
         Bindable ( true )]
        public bool Animate
            {

            get
                {
                return ( timer.Enabled );
                }

            set
                {
                timer.Enabled = value;
                }
            }

        // ******************************************* BackgroundColor

        [Category ( "CircularIndeterminateProgress" ),
         Description ( "Background color of the control" ),
         DefaultValue ( typeof ( SystemColors ), "Control" ),
         Bindable ( true )]
        public Color BackgroundColor
            {
            
            get
                {
                return ( background_color );
                }
                
            set
                {
                background_color = value;

                if ( control_graphic != null )
                    {
                    control_graphic =
                        control_graphic.DeleteGraphicsBuffer ( );
                    }

                if ( indicator_graphic != null )
                    {
                    indicator_graphic =
                        indicator_graphic.DeleteGraphicsBuffer ( );
                    }

                this.Invalidate ( );
                }
            }

        // ********************************************** CirclesCount
        
        [Category ( "CircularIndeterminateProgress" ),
         Description ( "Number of indicator circles" ),
         DefaultValue ( 5 ),
         Bindable ( true )]
        public int CirclesCount
            {
            get
                {
                return ( circles_count );
                }
            set
                {
                circles_count = value;
                circles_count = 
                    Math.Min (
                        Math.Max ( circles_count,
                                   MINIMUM_CIRCLES_COUNT ),
                        MAXIMUM_CIRCLES_COUNT );

                if ( control_graphic != null )
                    {
                    control_graphic =
                        control_graphic.DeleteGraphicsBuffer ( );
                    }
                if ( indicator_graphic != null )
                    {
                    indicator_graphic =
                        indicator_graphic.DeleteGraphicsBuffer ( );
                    }

                update_indicator_geometry ( );

                this.Invalidate ( );
                }
            }

        // **************************************** ControlWidthHeight

        [Category ( "CircularIndeterminateProgress" ),
         Description ( "Width and height of control" ),
         DefaultValue ( 30 ),
         Bindable ( true )]
        public int ControlWidthHeight
            {

            get
                {
                return ( control_width_height );
                }

            set
                {
                control_width_height = value;
                if ( ( control_width_height % 2 ) != 0 )
                    {
                    control_width_height++;
                    }
                control_width_height = 
                    Math.Min (
                        Math.Max ( control_width_height,
                                   MINIMUM_CONTROL_WIDTH_HEIGHT ),
                        MAXIMUM_CONTROL_WIDTH_HEIGHT );

                this.Width = control_width_height;
                this.Height = control_width_height;

                if ( control_graphic != null )
                    {
                    control_graphic =
                        control_graphic.DeleteGraphicsBuffer ( );
                    }
                if ( indicator_graphic != null )
                    {
                    indicator_graphic =
                        indicator_graphic.DeleteGraphicsBuffer ( );
                    }

                update_indicator_geometry ( );

                this.Invalidate ( );
                }
            }

        // ******************************************** IndicatorColor

        [Category ( "CircularIndeterminateProgress" ),
         Description ( "Color of first rotating indicator" ),
         DefaultValue ( typeof ( Color ), "Black" ),
         Bindable ( true )]
        public Color IndicatorColor
            {

            get
                {
                return ( indicator_color );
                }

            set
                {
                indicator_color = value;

                if ( indicator_graphic != null )
                    {
                    indicator_graphic =
                        indicator_graphic.DeleteGraphicsBuffer ( );
                    }

                this.Invalidate ( );
                }
            }

        // ***************************************** IndicatorDiameter

        [Category ( "CircularIndeterminateProgress" ),
         Description ( "Diameter of indicator circles" ),
         DefaultValue ( 8 ),
         Bindable ( true )]
        public int IndicatorDiameter
            {

            get
                {
                return ( indicator_diameter );
                }

            set
                {
                indicator_diameter = value;
                indicator_diameter =
                    Math.Min (
                        Math.Max ( indicator_diameter,
                                   MINIMUM_INDICATOR_DIAMETER ),
                        ( ControlWidthHeight / 2 ) );

                if ( ( indicator_diameter % 2 ) != 0 )
                    {
                    indicator_diameter--;
                    }

                if ( indicator_graphic != null )
                    {
                    indicator_graphic =
                        indicator_graphic.DeleteGraphicsBuffer ( );
                    }

                update_indicator_geometry ( );

                this.Invalidate ( );
                }
            }

        // ********************************************* IndicatorType

        [Category ( "CircularIndeterminateProgress" ),
         Description ( "Specifies if control is animated or pulsed" ),
         DefaultValue ( INDICATORTYPES.ANIMATED ),
         Bindable ( true )]
        public INDICATORTYPES IndicatorType
            {

            get
                {
                return ( indicator_type );
                }

            set
                {
                indicator_type = value;

                this.Invalidate ( );
                }
            }

        // *********************************************** RefreshRate
        [Category ( "CircularIndeterminateProgress" ),
         Description ( "Interval between indicator movements" ),
         DefaultValue ( 100 ),
         Bindable ( true )]
        public int RefreshRate
            {

            get
                {
                return ( refresh_rate );
                }

            set
                {
                bool  timer_running = timer.Enabled;

                refresh_rate = value;
                refresh_rate = Math.Min (
                                   Math.Max ( refresh_rate,
                                              MINIMUM_REFRESH_RATE ),
                                   MAXIMUM_REFRESH_RATE );

                if ( timer_running )
                    {
                    timer.Stop ( );
                    }
                timer.Interval = refresh_rate;
                if ( timer_running )
                    {
                    timer.Start ( );
                    }
                }
            }

        // ****************************************** OnPaint override

        /// <summary>
        /// take over the event handling for the control's OnPaint 
        /// event
        /// </summary>
        /// <param name="e">
        /// The PaintEventArgs class contains data for the Paint 
        /// event; of particular interest here is e.Graphics that has 
        /// methods to draw points, strings, lines, arcs, ellipses, 
        /// and other shapes
        /// </param>
        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);

            try
            {


                if (control_graphic == null)
                {
                    create_control_graphic();
                }
                control_graphic.RenderGraphicsBuffer(e.Graphics);

                create_indicator_graphic();
                indicator_graphic.RenderGraphicsBuffer(e.Graphics);
                // revise rotation angle and
                // avoid overflow
                indicator_angle += indicator_angular_advance;
                if (indicator_angle > (float)(2.0 * Math.PI))
                {
                    indicator_angle -= (float)(2.0 * Math.PI);
                }

            }
            catch (Exception e1)
            {

            }
        }
            

      } // class CircularIndeterminateProgress

    // ****************************************** class GraphicsBuffer
    
    public class GraphicsBuffer
        {
        private Bitmap		bitmap;
        private	Graphics    graphics;
        private	int			height;
        private	int			width;

        // ******************************** GraphicsBuffer constructor

        public GraphicsBuffer ( )
            {
            
            width = 0;
            height = 0;
            }

        // ************************************** CreateGraphicsBuffer

        /// <summary>
        /// Creates buffer object
        /// </summary>
        /// <param name="g">
        /// Window forms Graphics Object
        /// </param>
        /// <param name="width">
        /// Width of paint area
        /// </param>
        /// <param name="height">
        /// Height of paint area
        /// </param>
        /// <returns>
        /// true, if buffer created; otherwise, false
        /// </returns>
        public bool CreateGraphicsBuffer ( Graphics g,
                                           int      width,
                                           int      height )
            {
            bool  success = true;

            if ( bitmap != null )
                {
                bitmap.Dispose ( );
                bitmap = null;
                }

            if ( graphics != null )
                {
                graphics.Dispose ( );
                graphics = null;
                }

            if ( ( width == 0 ) || ( height == 0 ) )
                {
                success = false;
                }
            else if ( ( width != this.width ) ||
                      ( height != this.height ) )
                {
                this.width = width;
                this.height = height;

                bitmap = new Bitmap ( width, height );
                graphics = Graphics.FromImage ( bitmap );

                success = true;
                }
            else
                {
                success = true;
                }

            return ( success );
            }

        // ************************************** DeleteGraphicsBuffer

        public GraphicsBuffer DeleteGraphicsBuffer ( )
            {
            try
            {

                if (bitmap != null)
                {
                    bitmap.Dispose();
                    bitmap = null;
                }

                if (graphics != null)
                {
                    graphics.Dispose();
                    graphics = null;
                }

                width = 0;
                height = 0;
            }
            catch(Exception e)
            {

            }
            
            return ( null );
            }

        // ************************************************** g getter

        public Graphics g
            {

            get
                {
                return ( graphics );
                }
            }

        // ************************************** GraphicsBufferExists

        public bool GraphicsBufferExists
            {

            get
                {
                return ( graphics != null );
                }
            }

        // ************************************** RenderGraphicsBuffer

        /// <summary>
        /// Renders the buffer to the graphics object identified by g
        /// </summary>
        /// <param name="g">
        /// Window forms graphics object
        /// </param>
        public void RenderGraphicsBuffer(Graphics g)
        {
            try
            {
                if (bitmap != null)
                {
                    g.DrawImage(bitmap,
                                  new Rectangle(0, 0, width, height),
                                  0, 0,
                                  width, height,
                                  GraphicsUnit.Pixel);
                }

            }
            catch(Exception e)
            {

            }
            
         }


        } // class GraphicsBuffer
        
    } // namespace Utility
