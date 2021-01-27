import React, { useCallback } from "react";
import UserForm from "./UserForm";
import { Button } from "@material-ui/core";

const UserRegistrationForm = (props) => {
  // Function to register the user...
  const registerUser = useCallback((userData) => {
    // Call user api here with JWT

    let data = {
      username: userData.userName,
      password: userData.userPassword,
    };

    // Extracting the authenticated user from
    // the local storage and using the JWT token
    // to make further requests with this token.
    const authenticatedCurrentUser = JSON.parse(
      localStorage.getItem("currentUser")
    );

    const requestHeaderOptions = {
      method: "POST",
      body: JSON.stringify(data),
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${authenticatedCurrentUser.jwtToken}`,
      },
    };

    console.log("Register User request header = ", requestHeaderOptions);

    fetch("http://localhost:6060/users/register", requestHeaderOptions)
      .then((response) => {
        response.json().then((result) => {
          console.log("returned result = ", result);
        });
      })
      .catch((error) => {
        console.log("Error = ", error.data);
      });
  }, []);

  // Render block....
  return (
    <div>
      <UserForm buttonLabel="Register" onSubmitHandler={registerUser}>
        <Button type="submit" color="primary" variant="contained" size="small">
          Logout
        </Button>
      </UserForm>
    </div>
  );
};

export default UserRegistrationForm;
