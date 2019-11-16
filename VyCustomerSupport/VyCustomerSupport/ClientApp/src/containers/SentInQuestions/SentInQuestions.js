import React, {Component} from "react";
import "../../Styles.css";
import Header from "../../components/UI/Header/Header";
import UserQuestions from "../../components/UserQuesions/UserQuestions";
import Spinner from "../../components/UI/LoadingSpinner/LoadingSpinner";

const SENT_IN_INFO_TEXT = "Her kan du se brukerinnsendte spørsmål. Vi vil kontinuerlig prøve å besvare relevante spørsmål og legge de til i FAQ-siden.";
const TITLE = "Innsendte Spørsmål";

export class SentInQuestions extends Component {
    
    constructor(props) {
        super(props);
        
        this.state = {
            questions: [],
            loading: true,
            error: false
        };

        fetch("api/index/userquestions")
            .then(response => response.json())
            .then(questions => {
                this.setState({questions: questions, loading:false});
            })
            .catch(error => {
                this.setState({error: true});
            })
    }
    
    sentInContent() {
        return this.state.error ? <p className="ErrorMessage">Kan ikke laste inn spørsmål og svar. Vennligst kontroller Internetttilgangen </p> :
            this.state.loading ? <Spinner/> : 
                (<UserQuestions
                questions={this.state.questions}/>
        )
    }
    
    render() {
        const questionsContent = this.sentInContent();
        
        return(
            <div className="ContentArea">
                <Header
                    infoText={SENT_IN_INFO_TEXT}
                >{TITLE}</Header>
                {questionsContent}
            </div>
        )
    }
}