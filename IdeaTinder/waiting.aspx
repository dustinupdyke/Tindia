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
        <div id="content" class="grey-blue page">
            <!-- Toolbar -->
            <div id="toolbar" class="primary-color">
                <div class="open-left" id="open-left" data-activates="slide-out-left">
                </div>
                <span class="title">Digital Innovation's <em>Tindia</em></span>
                <div class="open-right" id="open-right" data-activates="slide-out">
                </div>
            </div>
            <div class="wrap">
                <h1>No new ideas :(</h1>
            </div>
            
            <div id="add">
                <div>
                    <textarea id="add-idea-text"></textarea>
                </div>
                <div>
                    <input id="add-idea-add" type="button" value="Add New" />
                </div>
                <div>
                    <br /><br />
                    <input id="btn" type="button" value="Clear All Votes" />
                </div>
            </div>
                        
        </div>
        <!-- End of Main Contents -->

    </div>
    <!-- End of Page Content -->

    <script type="text/javascript" src="content/jquery.min.js"></script>
    <script>
        function check() {
            $.ajax({
                type: 'GET',
                url: './api/ideas',
                //data: JSON.stringify({ "IdeaId": id, "Like": like, "CreatedBy": $("#createdby").val() }),
                contentType: "application/json",
                dataType: 'json'
            }).done(function (data) {
                if (data.length > 0)
                    window.location.href = "ideas.aspx";
            });
        }
        $(function () {
            check();
            window.setInterval(function () {
                check()
            }, 5000);
        });

        $('#btn').click(function (e) {
            e.preventDefault();
            $.ajax({
                type: 'DELETE',
                url: './api/votes/deleteall',
                contentType: "application/json",
                dataType: 'json'
            }).done(function (data) {
                window.location.href = "ideas.aspx";
            });
        });

        $('#add-idea-add').click(function (e) {
            e.preventDefault();
            $.ajax({
                type: 'POST',
                url: './api/ideas',
                data: JSON.stringify({ "Name": $('#add-idea-text').val(), "CreatedBy": $("#createdby").val() }),
                contentType: "application/json",
                dataType: 'json'
            }).done(function (data) {
                window.location.href = "ideas.aspx";
            });
        });
    </script>
</body>
</html>
