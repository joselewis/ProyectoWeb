<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Inherits="Tienda.Usuario.AgregarUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Crear cuenta</title>
    <script src="../Css/RegistroUsuario/JS_Registro_Usuario.js"></script>
    <link href="../Css/RegistroUsuario/Css_Registro_Usuario.css" rel="stylesheet" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <link href="css/RegistroUsuario.css" rel="stylesheet" />
    <link rel="canonical" href="https://getbootstrap.com/docs/5.0/examples/checkout/">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <link href="RegistrarProducto/form-validation.css" rel="stylesheet" />
    <script src="RegistrarProducto/form-validation.js"></script>
    <link href="../Css/RegistroUsuario/RegistrarUsuarioCss.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">
        <div class="container">
          <main>
            <br />
            <div class="row g-5">
              <div class="col-md-5 col-lg-4 order-md-last">
              </div>
              <div class="col-md-7 col-lg-8">
                <h4 class="mb-3">Registrarse</h4>

                <form class="needs-validation" novalidate>
                  <div class="row g-3">
                    <div class="col-sm-4">
                      <label for="firstName" class="form-label">Nombre</label>
                      <asp:TextBox runat="server"  class="form-control" ID="ReCajaNombre" placeholder=""></asp:TextBox>
                      <div class="invalid-feedback">
                        Valid first name is required.
                      </div>
                    </div>

                    <div class="col-sm-4">
                      <label for="lastName" class="form-label">Primer apellido</label>
                      <asp:TextBox runat="server"  class="form-control" ID="ReCajaApellido1" placeholder=""></asp:TextBox>
                      <div class="invalid-feedback">
                        Valid last name is required.
                      </div>
                    </div>

                    <div class="col-sm-4">
                        <label for="lastName" class="form-label">Segundo apellido</label>
                        <asp:TextBox runat="server"  class="form-control" ID="ReCajaApellido2" placeholder=""></asp:TextBox>
                    <div class="invalid-feedback">
                        Valid last name is required.
                    </div>
                    </div>

                    <div class="col-4">
                      <label for="username" class="form-label">Nombre de usuario</label>
                      <div class="input-group has-validation">
                        <asp:TextBox runat="server" class="form-control" ID="ReCajaNomUsuario" placeholder=""></asp:TextBox>
                      <div class="invalid-feedback">
                          Your username is required.
                        </div>
                      </div>
                    </div>

                    <div class="col-8">
                      <label for="email" class="form-label">Correo</label>
                      <asp:TextBox runat="server" type="email" class="form-control" id="ReCajaCorreo" placeholder="name@example.com"></asp:TextBox>
                      <div class="invalid-feedback">
                        Por favor ingrese un correo válido.
                      </div>
                    </div>

                    <div class="col-12">
                      <label for="address" class="form-label">Télefono</label>
                      <asp:TextBox runat="server"  class="form-control" id="ReCajaTelefono" placeholder="00000000"></asp:TextBox>
                      <div class="invalid-feedback">
                        Please enter your shipping address.
                      </div>
                    </div>

                    <div class="col-12">
                      <label for="address2" class="form-label">Contreseña</label>
                      <asp:TextBox runat="server" type="password" class="form-control" id="ReCajaContrasenna" placeholder="Password"></asp:TextBox>
                    </div>
                  </div> 
                    <asp:Label ID="lblCamposPagoNulo" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </div>
                <center class="col-8">
                    <asp:button runat="server" class="w-50 btn-black btn-lg" Text="Registrarse" ID="BotonRegistrarUsuario" OnClick="BotonRegistrarUsuario_Click" />              
                </center>
        </form>
  </main>
</form>
</body>
</html>
