AppOperations app = new AppOperations();


app.RegisterUser("Javad", "Bakirli", 25, "javad.bakirli@gmail.com", "password", "12345");


app.LoginUser("javad.bakirli@gmail.com", "12345");


app.ShowMainMenu();