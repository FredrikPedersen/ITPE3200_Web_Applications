import React, { Component } from "react";
import { MDBNotification } from "mdbreact";

//Taken from the template at https://mdbootstrap.com/docs/react/advanced/notifications/
class ToastDismissable extends Component {
    render() {
        return (
            <MDBNotification
                show
                fade
                iconClassName="text-primary"
                title={this.props.toastTitle}
                message={this.props.toastMessage}
                text="Nå nettopp"
                style={{position: "absolute", left: "80%", marginLeft: "-40px"}}
            />
        );
    }
}

export default ToastDismissable;