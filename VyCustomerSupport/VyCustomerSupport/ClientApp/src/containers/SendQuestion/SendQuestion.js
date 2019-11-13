﻿import React, {Component} from "react";
import "../../Styles.css";
import Header from "../../components/Header/Header";

const SEND_INFO_TEXT = "Noe du lurer på som ikke er besvart fra før? Send det inn her! Vi vil svare på så mange vi kan når vi har kapasitet.";
const TITLE = "Send inn Spørsmål";

export class SendQuestion extends Component {
    render() {
        return(
            <div className="ContentArea">
                <Header
                infoText={SEND_INFO_TEXT}
                >{TITLE}</Header>
            </div>
        );
    }
}