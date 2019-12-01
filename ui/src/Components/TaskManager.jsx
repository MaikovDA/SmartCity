import React, { Component } from 'react';
import '../Styles/TaskManager.scss';
import { connect } from 'react-redux';
import Actions from '../reducers/Actions';

class TaskManager extends Component {
  constructor() {
    super();
    this.state = {}
  }

  componentDidMount() {
  }

  handleClick = (e) => {
    console.log('!')
  }

  render() {
    return (
      <div className="task-manager-container" onClick={this.handleClick}>
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {state};
};

const mapDispatchToProps = (dispatch) => {
  return {
    actions: new Actions(dispatch)
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(TaskManager);