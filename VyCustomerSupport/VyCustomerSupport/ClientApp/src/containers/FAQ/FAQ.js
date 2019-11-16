import React, {Component} from 'react';
import "../../Styles.css";

import LoadingSpinner from "../../components/UI/LoadingSpinner/LoadingSpinner";
import Header from "../../components/UI/Header/Header";
import QuestionsAndAnswers from "../../components/QuestionsAndAnswers/QuestionsAndAnswers";

const FAQ_INFO_TEXT = "Hva lurer du på? Her finner du svar på spørsmål som vi har besvart";
const TITLE = "Spørsmål og Svar";

export class FAQ extends Component {
    static displayName = FAQ.name;


    constructor(props) {
        super(props);

        this.state = {
            qas: [],
            loading: true,
            error: false
        };

        fetch("api/index/qas")
            .then(response => response.json())
            .then(qas => {
                this.setState({qas: qas, loading: false});
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
        let qas =
            this.state.error ?
                <p className="ErrorMessage">FAQs can't be loaded. Please check your Internet connection!</p> :
                this.state.loading ? <LoadingSpinner/> :
                    this.qaContent();


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
