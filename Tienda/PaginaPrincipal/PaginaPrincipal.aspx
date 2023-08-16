<%@ Page Title="" Language="C#" MasterPageFile="~/PáginaPrincipal.Master" AutoEventWireup="true" CodeBehind="PaginaPrincipal.aspx.cs" Inherits="Tienda.PaginaPrincipal.PaginaPrincipal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/PaginaPrincipal/css/animate.css" rel="stylesheet" />
    <link href="../Css/PaginaPrincipal/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../Css/PaginaPrincipal/css/namari-color.css" rel="stylesheet" />
    <link href="../Css/PaginaPrincipal/css/style.css" rel="stylesheet" />
    <link href='https://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700,800' rel='stylesheet' type='text/css'>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="preloader">
    <div id="status" class="la-ball-triangle-path">
        <div></div>
        <div></div>
        <div></div>
    </div>
</div>
<!--End of Preloader-->

<div class="top-border wow fadeInDown animated" style="visibility: visible; animation-name: fadeInDown;"></div>
<div class="right-border wow fadeInRight animated" style="visibility: visible; animation-name: fadeInRight;"></div>
<div class="bottom-border wow fadeInUp animated" style="visibility: visible; animation-name: fadeInUp;"></div>
<div class="left-border wow fadeInLeft animated" style="visibility: visible; animation-name: fadeInLeft;"></div>

<div id="wrapper">
    <header id="banner" class="scrollto clearfix" data-enllax-ratio=".5">
        <!--Banner Content-->
        <div id="banner-content" class="row clearfix">

            <div class="col-38">

                <div class="section-heading">
                    <h1>SOMOS UNA TIENDA DE ROPA, PERO CON MICHIS</h1>
                </div>

                <!--Call to Action-->
                <a href="../Productos/Productos.aspx" class="button">VER PRODUCTOS</a>
                <!--End Call to Action-->

            </div>

        </div><!--End of Row-->
    </header>

    <!--Main Content Area-->
    <main id="content">

        <!--Introduction-->
        <section id="about" class="introduction scrollto">

            <div class="row clearfix">

                <div class="col-3">
                    <div class="section-heading">
                        <h3>SUCCESS</h3>
                        <h2 class="section-title">How We Help You To Sell Your Product</h2>
                        <p class="section-subtitle">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
                            eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam!</p>
                    </div>

                </div>

                <div class="col-2-3">

                    <!--Icon Block-->
                    <div class="col-2 icon-block icon-top wow fadeInUp" data-wow-delay="0.1s">
                        <!--Icon-->
                        <div class="icon">
                            <i class="fa fa-html5 fa-2x"></i>
                        </div>
                        <!--Icon Block Description-->
                        <div class="icon-block-description">
                            <h4>HTML5 &amp; CSS3</h4>
                            <p>Has ne tritani atomorum conclusionemque, in dolorum volumus cotidieque eum. At vis choro
                                neglegentur iudico</p>
                        </div>
                    </div>
                    <!--End of Icon Block-->

                    <!--Icon Block-->
                    <div class="col-2 icon-block icon-top wow fadeInUp" data-wow-delay="0.3s">
                        <!--Icon-->
                        <div class="icon">
                            <i class="fa fa-bolt fa-2x"></i>
                        </div>
                        <!--Icon Block Description-->
                        <div class="icon-block-description">
                            <h4>Easy to Use</h4>
                            <p>Cu vero ipsum vim, doctus facilisi sea in. Eam ex falli honestatis repudiandae, sit
                                detracto mediocrem disputationi</p>
                        </div>
                    </div>
                    <!--End of Icon Block-->

                    <!--Icon Block-->
                    <div class="col-2 icon-block icon-top wow fadeInUp" data-wow-delay="0.5s">
                        <!--Icon-->
                        <div class="icon">
                            <i class="fa fa-tablet fa-2x"></i>
                        </div>
                        <!--Icon Block Description-->
                        <div class="icon-block-description">
                            <h4>Fully Responsive</h4>
                            <p>Id porro tritani recusabo usu, eum intellegam consequuntur et. Fugit debet ea sit, an pro
                                nemore vivendum</p>
                        </div>
                    </div>
                    <!--End of Icon Block-->

                    <!--Icon Block-->
                    <div class="col-2 icon-block icon-top wow fadeInUp" data-wow-delay="0.5s">
                        <!--Icon-->
                        <div class="icon">
                            <i class="fa fa-rocket fa-2x"></i>
                        </div>
                        <!--Icon Block Description-->
                        <div class="icon-block-description">
                            <h4>Parallax Effect</h4>
                            <p>Id porro tritani recusabo usu, eum intellegam consequuntur et. Fugit debet ea sit, an pro
                                nemore vivendum</p>
                        </div>
                    </div>
                    <!--End of Icon Block-->

                </div>

            </div>


        </section>
        <!--End of Introduction-->


        <!--Gallery-->
        <aside id="gallery" class="row text-center scrollto clearfix" data-featherlight-gallery
                 data-featherlight-filter="a">

                <a href="../Css/PaginaPrincipal/images/gallery-images/Gallery-1.jpg" data-featherlight="image" class="col-3 wow fadeIn"
                   data-wow-delay="0.1s"><img src="../Css/PaginaPrincipal/images/gallery-images/Gallery-1.jpg" alt="Landing Page"/></a>
                <a href="../Css/PaginaPrincipal/images/gallery-images/Gallery-2.jpg" data-featherlight="image" class="col-3 wow fadeIn"
                   data-wow-delay="0.3s"><img src="../Css/PaginaPrincipal/images/gallery-images/Gallery-2.jpg" alt="Landing Page"/></a>
                <a href="../Css/PaginaPrincipal/images/gallery-images/Gallery-3.jpg" data-featherlight="image" class="col-3 wow fadeIn"
                   data-wow-delay="0.5s"><img src="../Css/PaginaPrincipal/images/gallery-images/Gallery-3.jpg" alt="Landing Page"/></a>
                <a href="../Css/PaginaPrincipal/images/gallery-images/Gallery-4.jpg" data-featherlight="image" class="col-3 wow fadeIn"
                   data-wow-delay="1.1s"><img src="../Css/PaginaPrincipal/images/gallery-images/Gallery-4.jpg" alt="Landing Page"/></a>
                <a href="../Css/PaginaPrincipal/images/gallery-images/Gallery-5.jpg" data-featherlight="image" class="col-3 wow fadeIn"
                   data-wow-delay="0.9s"><img src="../Css/PaginaPrincipal/images/gallery-images/Gallery-5.jpg" alt="Landing Page"/></a>
                <a href="../Css/PaginaPrincipal/images/gallery-images/Gallery-6.jpg" data-featherlight="image" class="col-3 wow fadeIn"
                   data-wow-delay="0.7s"><img src="../Css/PaginaPrincipal/images/gallery-images/Gallery-6.jpg" alt="Landing Page"/></a>

        </aside>
        <!--End of Gallery-->


        <!--Content Section-->
        <div id="services" class="scrollto clearfix">

            <div class="row no-padding-bottom clearfix">


                <!--Content Left Side-->
                <div class="col-3">
                    <!--User Testimonial-->
                    <blockquote class="testimonial text-right bigtest">
                        <q>
                            Miauuu
                        </q>
                        <footer>— El Michi</footer>
                    </blockquote>
                    <!-- End of Testimonial-->

                </div>
                <!--End Content Left Side-->

                <!--Content of the Right Side-->
                <div class="col-3">
                    <div class="section-heading">
                        <h3>MICHIS</h3>
                        <h2 class="section-title">¿Por qué la tieda se llama Michi's?</h2>
                        <p class="section-subtitle">Porque me gustan los michis, ¿Tiene algun problema con eso?.</p>
                    </div>
                    <p>Según estudios recientes, los michis son beneficiosos para la salud emocional, 
                        y mejor aún, juntarlo con una tienda de ropa para que sea su nombre y logo.
                    </p>
                    
                    <!-- Just replace the Video ID "UYJ5IjBRlW8" with the ID of your video on YouTube (Found within the URL) -->
                    <a href="#" data-videoid="UYJ5IjBRlW8" data-videosite="youtube" class="button video link-lightbox">
                        WATCH VIDEO <i class="fa fa-play" aria-hidden="true"></i>
                    </a>
                </div>
                <!--End Content Right Side-->

                <div class="col-3">
                    <img src="../Css/PaginaPrincipal/images/user-images/MichiNegro.png"/>
                </div>

            </div>


        </div>
        <!--End of Content Section-->
        <center>
            <!--Testimonials-->
            <aside id="testimonials" class="scrollto text-center" data-enllax-ratio=".2">

                <div class="row clearfix">

                    <div class="section-heading">
                        <h3>CREADOR</h3>
                        <h2 class="section-title">Programador de la página web</h2>
                    </div>

                    <!--User Testimonial-->
                    <blockquote class="col-1 testimonial classic">
                        <img src="../Css/PaginaPrincipal/images/user-images/Yo.jpg" alt="User"/>
                        <q>Estudiante de la Escuela de Ingeniería Informática 
                            de la Universidad Internacional de las Américas</q>
                        <footer>José Francisco Gutiérrez Lewis</footer>
                    </blockquote>
                    <!-- End of Testimonial-->

                </div>

            </aside>
            <!--End of Testimonials-->
        </center>
        <!--Clients-->
        <section id="clients" class="scrollto clearfix">
            <div class="row clearfix">

                <div class="col-3">

                    <div class="section-heading">
                        <h3>TRUST</h3>
                        <h2 class="section-title">Companies who use our services</h2>
                        <p class="section-subtitle">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
                            eiusmod
                            tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam!</p>
                    </div>

                </div>

                <div class="col-2-3">

                    <a href="#" class="col-3">
                        <img src="../Css/PaginaPrincipal/images/company-images/company-logo1.png" alt="Company"/>
                        <div class="client-overlay"><span>Tree</span></div>
                    </a>
                    <a href="#" class="col-3">
                        <img src="../Css/PaginaPrincipal/images/company-images/company-logo2.png" alt="Company"/>
                        <div class="client-overlay"><span>Fingerprint</span></div>
                    </a>
                    <a href="#" class="col-3">
                        <img src="../Css/PaginaPrincipal/images/company-images/company-logo3.png" alt="Company"/>
                        <div class="client-overlay"><span>The Man</span></div>
                    </a>
                    <a href="#" class="col-3">
                        <img src="../Css/PaginaPrincipal/images/company-images/company-logo4.png" alt="Company"/>
                        <div class="client-overlay"><span>Mustache</span></div>
                    </a>
                    <a href="#" class="col-3">
                        <img src="../Css/PaginaPrincipal/images/company-images/company-logo5.png" alt="Company"/>
                        <div class="client-overlay"><span>Goat</span></div>
                    </a>
                    <a href="#" class="col-3">
                        <img src="../Css/PaginaPrincipal/images/company-images/company-logo6.png" alt="Company"/>
                        <div class="client-overlay"><span>Justice</span></div>
                    </a>
                    <a href="#" class="col-3">
                        <img src="../Css/PaginaPrincipal/images/company-images/company-logo7.png" alt="Company"/>
                        <div class="client-overlay"><span>Ball</span></div>
                    </a>
                    <a href="#" class="col-3">
                        <img src="../Css/PaginaPrincipal/images/company-images/company-logo8.png" alt="Company"/>
                        <div class="client-overlay"><span>Cold</span></div>
                    </a>

                    <a href="#" class="col-3">
                        <img src="../Css/PaginaPrincipal/images/company-images/company-logo9.png" alt="Company"/>
                        <div class="client-overlay"><span>Cold</span></div>
                    </a>

                </div>

            </div>
        </section>
        <!--End of Clients-->

        <!--Pricing Tables-->
        <section id="pricing" class="secondary-color text-center scrollto clearfix ">
            <div class="row clearfix">

                <div class="section-heading">
                    <h3>YOUR CHOICE</h3>
                    <h2 class="section-title">We have the right package for you</h2>
                </div>

                <!--Pricing Block-->
                <div class="pricing-block col-3 wow fadeInUp" data-wow-delay="0.4s">
                    <div class="pricing-block-content">
                        <h3>Personal</h3>
                        <p class="pricing-sub">The standard version</p>
                        <div class="pricing">
                            <div class="price"><span>$</span>19</div>
                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit</p>
                        </div>
                        <ul>
                            <li>5 Downloads</li>
                            <li>2 Extensions</li>
                            <li>Tutorials</li>
                            <li>Forum Support</li>
                            <li>1 year free updates</li>
                        </ul>
                        <a href="#" class="button">BUY TODAY</a>
                    </div>
                </div>
                <!--End Pricing Block-->

                <!--Pricing Block-->
                <div class="pricing-block featured col-3 wow fadeInUp" data-wow-delay="0.6s">
                    <div class="pricing-block-content">
                        <h3>Student</h3>
                        <p class="pricing-sub">Most popular choice</p>
                        <div class="pricing">
                            <div class="price"><span>$</span>29</div>
                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit</p>
                        </div>
                        <ul>
                            <li>15 Downloads</li>
                            <li>5 Extensions</li>
                            <li>Tutorials with Files</li>
                            <li>Forum Support</li>
                            <li>2 years free updates</li>
                        </ul>
                        <a href="#" class="button">BUY TODAY</a>
                    </div>
                </div>
                <!--End Pricing Block-->

                <!--Pricing Block-->
                <div class="pricing-block col-3 wow fadeInUp" data-wow-delay="0.8s">
                    <div class="pricing-block-content">
                        <h3>Business</h3>
                        <p class="pricing-sub">For the whole team</p>
                        <div class="pricing">
                            <div class="price"><span>$</span>49</div>
                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit</p>
                        </div>
                        <ul>
                            <li>Unlimited Downloads</li>
                            <li>Unlimited Extensions</li>
                            <li>HD Video Tutorials</li>
                            <li>Chat Support</li>
                            <li>Lifetime free updates</li>
                        </ul>
                        <a href="#" class="button">BUY TODAY</a>
                    </div>
                </div>
                <!--End Pricing Block-->

            </div>
        </section>
        <!--End of Pricing Tables-->

    </main>
    <!--End Main Content Area-->
</div>

<!-- Include JavaScript resources -->
    <script src="../Css/PaginaPrincipal/js/featherlight.gallery.min.js"></script>
    <script src="../Css/PaginaPrincipal/js/featherlight.min.js"></script>
    <script src="../Css/PaginaPrincipal/js/images-loaded.min.js"></script>
    <script src="../Css/PaginaPrincipal/js/jquery.easing.min.js"></script>
    <script src="../Css/PaginaPrincipal/js/jquery.1.8.3.min.js"></script>
    <script src="../Css/PaginaPrincipal/js/jquery.enllax.min.js"></script>
    <script src="../Css/PaginaPrincipal/js/jquery.scrollUp.min.js"></script>
    <script src="../Css/PaginaPrincipal/js/jquery.stickyNavbar.min.js"></script>
    <script src="../Css/PaginaPrincipal/js/jquery.waypoints.min.js"></script>
    <script src="../Css/PaginaPrincipal/js/lightbox.min.js"></script>
    <script src="../Css/PaginaPrincipal/js/site.js"></script>
    <script src="../Css/PaginaPrincipal/js/wow.min.js"></script>
</asp:Content>
