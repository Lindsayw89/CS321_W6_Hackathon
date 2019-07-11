import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { actionCreators } from '../store/Quiz';
import { withRouter } from 'react-router-dom';

import StartQuiz from './StartQuiz';
import EndQuiz from './EndQuiz';
import ShowQuestion from './ShowQuestion';
import Stepper from './Stepper';

class TakeQuiz extends React.Component {
  state = {
    questionIndex: 0,
  };

  componentDidMount() {
    const { quiz } = this.props;
    const quizId = this.props.match.params.quizId;
    if (!quiz || quiz.id !== quizId) {
      this.props.requestQuiz(quizId);
    }
  }

  getQuestions = () => {
    const { quiz } = this.props;
    if (!quiz || !quiz.questions) return [];
    return quiz.questions;
  };

  isQuizNotStarted = () => {
    const { questionIndex } = this.state;
    return questionIndex < 0;
  };

  isQuizInProgress = () => {
    const { questionIndex } = this.state;
    const questions = this.getQuestions();
    return questionIndex >= 0 && questionIndex < questions.length;
  };

  isQuizCompleted = () => {
    const { questionIndex } = this.state;
    const questions = this.getQuestions();
    return questionIndex >= questions.length;
  };

  handleStartQuiz = () => {
    const { questionIndex } = this.state;
    this.setState({
      questionIndex: questionIndex + 1,
    });
  };

  handleCancelQuiz = () => {
    this.props.history.goBack();
  };

  handleNextQuestion = () => {
    const { questionIndex } = this.state;
    this.setState({
      questionIndex: questionIndex + 1,
    });
  };

  handlePrevQuestion = () => {
    const { questionIndex } = this.state;
    this.setState({
      questionIndex: questionIndex - 1,
    });
  };

  render() {
    const { questionIndex } = this.state;
    const { quiz } = this.props;
    const questions = this.getQuestions();
    //const classes = useStyles();
    const questionCards = [
      <StartQuiz
        quiz={quiz}
        onStart={this.handleStartQuiz}
        onCancel={this.handleCancelQuiz}
      />,
      ...questions.map((q) => <ShowQuestion question={q} />),
      <EndQuiz quiz={quiz} />,
    ];
    return (
      <React.Fragment>
        <Stepper
          items={questionCards}
          activeStep={questionIndex}
          onNext={this.handleNextQuestion}
          onBack={this.handlePrevQuestion}
        />
      </React.Fragment>
    );
  }
}

export default connect(
  (state) => state.quiz,
  (dispatch) => bindActionCreators(actionCreators, dispatch)
)(withRouter(TakeQuiz));