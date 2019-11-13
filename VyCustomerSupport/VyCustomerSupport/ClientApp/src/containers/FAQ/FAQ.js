import React, {Component} from 'react';
import "../../Styles.css";
import "./FAQ.css"

import LoadingSpinner from "../../components/UI/LoadingSpinner/LoadingSpinner";
import Header from "../../components/Header/Header";
import QuestionsAndAnswers from "../../components/QuestionsAndAnswers/QuestionsAndAnswers";

const FAQ_INFO_TEXT = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.";

export class FAQ extends Component {
    static displayName = FAQ.name;


    constructor(props) {
        super(props);

        this.state = {
            qas: [],
            loading: false,
            error: false
        };

        fetch("api/index/qas")
            .then(response => response.json())
            .then(qas => {
                this.setState({qas: qas});
            })
            .catch(error => {
                this.setState({error: true});
            })
    }

    qaContent() {
        return (
            <QuestionsAndAnswers
                questionsAndAnswers={this.state.qas}/>
        )
    }

    render() {
        let qas = this.state.error ?
            <p className="ErrorMessage">FAQs can't be loaded. Please check your Internet connection!</p> :
            <LoadingSpinner/>;

        if (this.state.qas) {
            qas = this.qaContent();
        }

        return (
            <div className="ContentArea">
                <Header
                    infoText={FAQ_INFO_TEXT}
                >Frequently Asked Questions</Header>
                {qas}
            </div>
        );
    }
}
