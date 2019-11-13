﻿import React from "react";
import "./Header.css";

const header = (props) => (
    <div className="Header">
        <h1>{props.children}</h1>
        <p>{props.infoText}</p>
    </div>
);

export default header;