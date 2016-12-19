<%@ Page Language="C#" %>

<!DOCTYPE html>
<html>
<head>
    <meta content="IE=edge" http-equiv="x-ua-compatible">
    <meta content="initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no" name="viewport">
    <meta content="yes" name="apple-mobile-web-app-capable">
    <meta content="yes" name="apple-touch-fullscreen">
    <!-- Fonts -->
    <link href='https://fonts.googleapis.com/css?family=Open+Sans:400,300,700' rel='stylesheet' type='text/css'>
    <!-- Icons -->
    <link href="http://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" media="all" rel="stylesheet" type="text/css">
    <!-- Styles -->
    <link href="css/keyframes.css" rel="stylesheet" type="text/css">
    <link href="css/materialize.min.css" rel="stylesheet" type="text/css">
    <link href="css/swiper.css" rel="stylesheet" type="text/css">
    <link href="css/swipebox.min.css" rel="stylesheet" type="text/css">
    <link href="css/style.css" rel="stylesheet" type="text/css">

    <link rel="stylesheet" type="text/css" href="content/jTinder.css">
</head>
<body class="grey-blue">
    <div class="m-scene" id="main">

        <!-- Page Content -->
        <div id="content" class="grey-blue page">

            <!-- Toolbar -->
            <div id="toolbar" class="primary-color">
                <div class="open-left" id="open-left" data-activates="slide-out-left">
                </div>
                <span class="title">Digital Innovation's <em>Tindia™</em></span>
                <div class="open-right" id="open-right" data-activates="slide-out">
                </div>
            </div>


            <!-- start padding container -->
            <div class="wrap">
                <!-- start jtinder container -->
                <div id="tinderslide">
                    <ul id="tinderslide-items">
                    </ul>
                </div>
                <!-- end jtinder container -->
            </div>
            <!-- end padding container -->

            <!-- jTinder trigger by buttons  -->
            <div class="actions">
                <a href="#" class="dislike"><i></i></a>
                <a href="#" class="like"><i></i></a>
            </div>

            <!-- jTinder status text  -->
            <div id="status"></div>
            <input type="hidden" id="createdby" name="createdby" value="M104203<%=User.Identity.Name.Replace("MYL\\","")%>">

            <div id="add">
                <div>
                    <textarea id="add-idea-text"></textarea>
                </div>
                <div>
                    <input id="add-idea-add" type="button" value="Add New" />
                </div>
            </div>
            
        </div>
        <!-- End of Main Contents -->
        
    </div>
    <!-- End of Page Content -->
    
    <!-- jQuery lib -->
    <script type="text/javascript" src="content/jquery.min.js"></script>
    <!-- transform2d lib -->
    <script type="text/javascript" src="content/jquery.transform2d.js"></script>
    <!-- jTinder lib -->
    <script type="text/javascript" src="content/jquery.jTinder.js"></script>
    <!-- jTinder initialization script -->
    <script type="text/javascript" src="content/main.js"></script>

</body>
</html>
