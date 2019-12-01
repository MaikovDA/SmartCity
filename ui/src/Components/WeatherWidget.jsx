import React, { Component, Fragment } from 'react';
import '../Styles/WeatherWidget.scss';
import { connect } from 'react-redux';
import Actions from '../reducers/Actions';
import Cloudy from '../assets/Cloudy.png'

class WeatherWidget extends Component {

  componentDidMount() {
    const { actions } = this.props;

    actions.getWeather();
  }

  handleClick = (e) => {
  }

  render() {
    const { weatherState } = this.props;

    var today = new Date;

    let hour = today.getHours();
    let minute = today.getMinutes();

    return (
      <Fragment>
        <div className="weather-widget">
          <img className="widget_icon" src={Cloudy} alt="Cloudy" />
          <span className="widget_hour">{hour}:{minute}</span>
          <span className="widget_temp">-5 C</span>
        </div>
      </Fragment>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    weatherState: state.weather,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    actions: new Actions(dispatch)
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(WeatherWidget);