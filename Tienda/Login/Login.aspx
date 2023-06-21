<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Tienda.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Iniciar Sesión</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
	<link href="https://fonts.googleapis.com/css?family=Lato:300,400,700&display=swap" rel="stylesheet">
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <link href="../Css/Login/css/style.css" rel="stylesheet" />
    <link href="../Css/Login/css/bootstrap/LoginCss.css" rel="stylesheet" />
</head>
<body class="img js-fullheight" ">
	<section class="ftco-section">
		<div class="container">
			<div class="row justify-content-center">
				<div class="col-md-6 text-center mb-5">
					<h2 class="heading-section">Tienda</h2>
				</div>
			</div>
			<div class="row justify-content-center">
				<div class="col-md-6 col-lg-4">
					<div class="login-wrap p-0">
		      	<h3 class="mb-4 text-center">Inicio de sesión</h3>
		      	<form runat="server" action="#" class="signin-form">
		      		<div class="form-group">
						<asp:TextBox runat="server" ID="CajaUsuario" type="text" class="form-control" placeholder="Usuario" required></asp:TextBox>
		      		</div>
	            <div class="form-group">
	              <asp:TextBox runat="server" ID="CajaContrasenna" type="password" class="form-control" placeholder="Contraseña" required></asp:TextBox>
	              <span toggle="#password-field" class="fa fa-fw fa-eye field-icon toggle-password"></span>
	            </div>
	            <div class="form-group">
					<asp:Button runat="server" ID="BotonInicioSesion" OnClick="BotonInicioSesion_Click" Text="Ingresar" class="form-control btn btn-primary submit px-3" />
	            </div>
				<center>
					<a href="../Usuario/AgregarUsuario.aspx" style="color: #fff">Registrarse</a>
			   </center>
	          </form>
		      </div>
			  </div>
			</div>
		</div>
	</section>
	<script src="Login/js/jquery.min.js"></script>
	<script src="Login/js/popper.js"></script>
	<script src="Login/js/bootstrap.min.js"></script>
	<script src="Login/js/main.js"></script>
</body>
</html>
