import React, { Component } from 'react';
import connectYaMaps from "../Utils/connectYaMaps";
import { connect } from 'react-redux';
import '../Styles/Map.scss';

const yandexPath = "https://api-maps.yandex.ru/2.1/?apikey=7babf210-1aac-4782-8182-b441bbcea451&lang=ru_RU";

class Map extends Component {
  yandexMap;
  multiRoute;

  constructor(props) {
    super(props);
  }

  componentDidMount() {
    connectYaMaps(yandexPath)
      .then((ymaps) => ymaps.ready(this.initMaps));
  }

  initMaps = (ymaps) => {
    const { mapState } = this.props;
    this.multiRoute = new ymaps.multiRouter.MultiRoute({
      referencePoints: [
        [55.76113, 37.736136],
        [55.779783, 37.742258],
        [55.762043, 37.715592]
      ],
      params: {
        results: 1
      }
    }, {
      boundsAutoApply: true
    });

    let multiRouteTwo = new ymaps.multiRouter.MultiRoute({
      referencePoints: [
        "Москва, ул. Новый Арбат",
        "Москва, ул. Плющиха",
        "Москва, ул. Новый Арбат"
      ],
      params: {
        results: 1
      }
    }, {
      boundsAutoApply: true,
      routeActiveStrokeColor: "000000",
    });

    this.yandexMap = new ymaps.Map('map', mapState);

    this.yandexMap.geoObjects.add(this.multiRoute);
    this.yandexMap.geoObjects.add(multiRouteTwo);
  }

  render() {
    return <div id="map" />
  }
}

const mapStateToProps = (state) => {
  return {
    mapState: state.YAMapState
  };
};

export default connect(mapStateToProps)(Map);