import React from "react";
import "./VotingArea.css";

const votingArea = (props) => {
    let output = null;

    props.voted ?
        (output = (
                <div className="VotingArea">
                    <img className="VoteArrow" src="https://i.imgur.com/sPbn20T.png"/>
                    <p className="Positive"><strong>{props.upVotes}</strong></p>
                    <img className="VoteArrow" src="https://i.imgur.com/505R8AT.png"/>
                    <p className="Negative"><strong>{props.downVotes}</strong></p>
                </div>)
        ) :
        (output =
            (<div className="VotingArea">
                    <i>Synes du dette var nyttig?</i>
                    <img onClick={props.upVoteClick} className="VoteArrow" src="https://i.imgur.com/sPbn20T.png"/>
                    <img onClick={props.downVoteClick} className="VoteArrow" src="https://i.imgur.com/505R8AT.png"/>
                </div>
            ));

    return output;
};

export default votingArea;