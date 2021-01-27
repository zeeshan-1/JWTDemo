import React, { useCallback } from "react";
import UserForm from "./UserForm";

const UserRegistrationForm = (props) => {
  // Function to handle the user authentication
  const authenticateUser = useCallback((userData) => {
    // Call user api here with JWT
    let data = {
      username: userData.userName,
      password: userData.userPassword,
    };

    const requestHeaderOptions = {
      method: "POST",
      body: JSON.stringify(data),
      headers: { "Content-Type": "application/json" },
    };

    console.log("Authenticate User request header = ", requestHeaderOptions);

    fetch("http://localhost:6060/users/authenticate", requestHeaderOptions)
      .then((response) => {
        response.json().then((result) => {
          let currentUser = {
            id: result.id,
            userName: result.username,
            email: result.email,
            isRegistered: result.id > 0 ? true : false,
            isAuthenticated: result.jwtToken ? true : false,
            jwtToken: result.jwtToken,
            hasError: result.hasError,
            errorMessages: result.errorMessages,
          };

          console.log("returned result = ", currentUser);
          // Storing the user in local storage
          localStorage.setItem("currentUser", JSON.stringify(currentUser));

          // changing the state of the parent component to
          // toggle between the registration and authentication
          // form components.
          props.onAuthenticate(currentUser.isAuthenticated);
        });
      })
      .catch((error) => {
        console.log("Error = ", error);
      });
  }, []);

  // Render block....
  return (
    <div>
      <UserForm
        buttonLabel="Login"
        onSubmitHandler={authenticateUser}
      ></UserForm>
    </div>
  );
};

export default UserRegistrationForm;
