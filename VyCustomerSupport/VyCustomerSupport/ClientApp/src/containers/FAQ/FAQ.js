import React, {Component} from 'react';
import "../../Styles.css";

import LoadingSpinner from "../../components/UI/LoadingSpinner/LoadingSpinner";
import Header from "../../components/Header/Header";
import QuestionsAndAnswers from "../../components/QuestionsAndAnswers/QuestionsAndAnswers";

const FAQ_INFO_TEXT = "Hva lurer du på? Velg tema og finn svar på alt fra hvem som kan få rabatt og hvordan du søker om refusjon til hvordan appen fungerer og hva slags bagasje du kan ta med om bord. ";
const TITLE = "Spørsmål og Svar";

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
                >{TITLE}</Header>
                {qas}
            </div>
        );
    }
}
