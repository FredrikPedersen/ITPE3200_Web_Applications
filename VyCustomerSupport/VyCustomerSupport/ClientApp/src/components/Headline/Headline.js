﻿import React from "react";
import "./Headline.css";

const headline = (props) => (
    <div className="Headline">
        <h1>{props.children}</h1>
        <p>{props.infoText}</p>
    </div>
);

export default headline;