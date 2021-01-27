import logo from "./logo.svg";
import "./App.css";
import React, { useState, useEffect } from "react";
import { Container } from "@material-ui/core";
import UserRegistrationForm from "./Components/UserRegistrationForm";
import UserAuthenticationForm from "./Components/UserAuthenticationForm";

function App() {
  const [isRegistered, setIsRegistered] = useState(true);
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  useEffect(() => {}, [isAuthenticated, isRegistered]);

  return (
    <div className="App">
      <Container>
        {!isAuthenticated ? (
          <UserAuthenticationForm
            onAuthenticate={setIsAuthenticated}
          ></UserAuthenticationForm>
        ) : (
          <UserRegistrationForm
            onRegister={setIsRegistered}
          ></UserRegistrationForm>
        )}
      </Container>
    </div>
  );
}

export default App;
