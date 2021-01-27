import React, { useState } from "react";
import { Paper, Button, TextField, makeStyles } from "@material-ui/core";
import PropTypes from "prop-types";

// Customizing the default material-ui styles
// by using makeStyles hook technique
const useStyles = makeStyles((theme) => ({
  root: {
    "& .MuiTextField-root": {
      margin: theme.spacing(1),
      minWidth: 230,
    },
  },
  smMargin: {
    margin: theme.spacing(1),
  },
  paper: {
    margin: theme.spacing(4),
    padding: theme.spacing(2),
    width: theme.spacing(36),
    height: theme.spacing(23),
  },
}));

// User Form component
const UserForm = React.memo(({ buttonLabel, onSubmitHandler }) => {
  // State Variables
  const cssClasses = useStyles();
  const [enteredUserName, setEnteredUserName] = useState("");
  const [enteredUserPassword, setEnteredUserPassword] = useState("");

  // Event Handlers...
  const submitHandler = (event) => {
    event.preventDefault();

    // Passing the state object to the function
    // provided as props. By doing this the consumer
    // of this form can handle the submission with
    // custom logic/behaviour outside this component.
    onSubmitHandler({
      userName: enteredUserName,
      userPassword: enteredUserPassword,
    });
  };

  // Render block....
  return (
    <Paper className={cssClasses.paper} elevation={3}>
      <form
        className={cssClasses.root}
        noValidate
        autoComplete="off"
        onSubmit={submitHandler}
      >
        <div>
          <div>
            <TextField
              name="UserName"
              variant="outlined"
              label="User Name/Email"
              defaultValue={enteredUserName}
              autoComplete="current-username" // Added to avoid warnings
              onChange={(event) => {
                setEnteredUserName(event.target.value);
              }}
            ></TextField>
          </div>
          <div>
            <TextField
              name="Password"
              type="password"
              variant="outlined"
              label="Password"
              autoComplete="current-password" // Added to avoid warnings
              defaultValue={enteredUserPassword}
              onChange={(event) => {
                setEnteredUserPassword(event.target.value);
              }}
            ></TextField>
          </div>
          <div>
            <Button
              type="submit"
              color="primary"
              variant="contained"
              size="small"
              className={cssClasses.smMargin}
            >
              {buttonLabel}
            </Button>
          </div>
        </div>
      </form>
    </Paper>
  );
});

// Making all the props type safe by declaring their types
UserForm.propTypes = {
  buttonLabel: PropTypes.string,
  onSubmitHandler: PropTypes.func,
};
export default UserForm;
