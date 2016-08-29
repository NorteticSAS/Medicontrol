<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Construccion.aspx.cs" Inherits="Medicontrol.Construccion" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Demo mbComingsoon</title>
    <link href="ContadorStyles/style.min.css" rel="stylesheet" />
    <link href="ContadorStyles/mb-comingsoon-iceberg.css" rel="stylesheet" />
</head>
<body style="color:#808080">
    <section class="dark-blue color-2 ">
        <div class="inner-page">
            <div class="row">
                <div class="col-xs-4 col-xs-offset-4">
                </div>
            </div>
            <div class="text-center hgroup">
                <h1 style="color:black" class="page-headline large">Nos vemos pronto</h1>
                <h3 style="color:black">Nos estamos preparando</h3>
                <h4 style="color:black">NORTETIC SAS</h4>
                
            </div>
        </div>
        <div class="row centered text-center" id="myCounter"></div>
       

    </section>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script>
        if (typeof jQuery == 'undefined') {
            document.write(unescape("%3Cscript src='https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js' type='text/javascript'%3E%3C/script%3E"));
        }
    </script>
    <script src="ContadorStyles/jquery.mb-comingsoon.min.js"></script>
    <script type="text/javascript">
        $(function () {
            var $section = $('section');
            $(window).on("resize", function () {
                var dif = Math.max($(window).height() - $section.height(), 0);
                var padding = Math.floor(dif / 2) + 'px';
                $section.css({ 'padding-top': padding, 'padding-bottom': padding });
            }).trigger("resize");
            $('#myCounter').mbComingsoon({ expiryDate: new Date(2017, 0, 1, 9, 30), speed: 100 });
            setTimeout(function () {
                $(window).resize();
            }, 200);
        });

    </script>

</body>
</html>
