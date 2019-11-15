import React from "react";
import "./InputElement.css";

const inputElement = (props) => {
    let inputElement = null;
    let label = <p>{props.label}</p>;

    const inputStyles = ["InputArea"];

    if (props.invalid && props.shouldValidate && props.touched) {
        inputStyles.push("Invalid");
    }

    if (props.invalid && props.touched) {
        label = <p className={"ValidationError"}>{props.label} Vennligst oppgi en gyldig verdi!</p>
    }

    switch (props.elementType) {
        case ("input"):
            inputElement = <input
                className={inputStyles.join(" ")}
                {...props.elementConfig}
                value={props.value}
                onChange={props.changed}/>;
            break;

        case ("textarea"):
            inputElement = <textarea
                className={inputStyles.join(" ")}
                {...props.elementConfig}
                value={props.value}
                onChange={props.changed}/>;
            break;

        default:
            inputElement = <input
                className={inputStyles.join(" ")}
                {...props.elementConfig}
                value={props.value}
                onChange={props.changed} />;
            break;
    }
    
    return (
        <div className={"InputElement"}>
            <label className={"Label"}>{label}</label>
            {inputElement}
        </div>
    );
};

export default inputElement;