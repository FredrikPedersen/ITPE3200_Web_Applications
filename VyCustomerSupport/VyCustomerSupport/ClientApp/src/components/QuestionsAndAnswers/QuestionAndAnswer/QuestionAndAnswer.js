import React, {Component} from "react";
import "./QuestionAndAnswer.css";

import VotingArea from "../../VotingArea/VotingArea";

class QuestionAndAnswer extends Component {
    state = {
        expanded: false,
        voted: false,
        upVotes: this.props.upVotes,
        downVotes: this.props.downVotes,
        error: false
    };

    expansionHandler = () => {
        let isExpanded = this.state.expanded;
        this.setState({expanded: !isExpanded})
    };
    
    upVoteHandler = () => {
        const id = this.props.id;
        
        fetch("api/index/upvote/"+id, {
            method: "Post"
        })
            .then(response =>  {
                response.json();
                this.setState({voted: true});
            })
            .catch(error => this.setState({error: true}));
    };
    
    downVoteHandler = () => {
        const id = this.props.id;

        fetch("api/index/downvote/"+id, {
            method: "Post"
        })
            .then(response => {
                response.json();
                this.setState({voted: true});
            })
            .catch(error => this.setState({error: true}));
    };

    render() {
        let output = (
            <div className="QuestionButton" onClick={this.expansionHandler}
            >{this.props.question}
                <img src="https://cdn.iconscout.com/icon/free/png-256/chevron-20-433508.png"/>
            </div>
        );

        if (this.state.expanded) {
            output = (
                <div className="QandABox">
                    <div onClick={this.expansionHandler}>
                        <div className="Question">{this.props.question}<img
                            src="https://cdn.iconscout.com/icon/free/png-256/chevron-23-433511.png"/></div>
                        <div className="Answer">{this.props.answer}</div>
                    </div>
                        <VotingArea
                            upVotes={this.state.upVotes}
                            downVotes={this.state.downVotes}
                            voted={this.state.voted}
                            upVoteClick={this.upVoteHandler}
                            downVoteClick={this.downVoteHandler}/>
                </div>
            );
        }
        return output;
    }
}

export default QuestionAndAnswer;