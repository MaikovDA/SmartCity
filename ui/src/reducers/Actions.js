export default class Actions {
	dispatch;

	constructor(dispatch) {
		this.dispatch = dispatch;
	}

	setMapState(state) {
		this.dispatch({ type: 'SET_STATE', payload: state });
	}

	setRouteState(state) {
		this.dispatch({ type: 'SET_ROUTE', payload: state });
	}

	setActiveTab(tab) {
		this.dispatch({ type: 'SET_TAB', payload: tab });
	}

	getWeather() {
		fetch('https://api.weather.yandex.ru/v1/forecast?lat=55.75396&lon=37.620393&extra=true', {
			headers: {
				'X-Yandex-API-Key': 'd3003b75-4ff8-41a3-89ac-7fe9f8b814b4'
			}
		})
			.then((response) => {
				return response.json();
			})
			.then((weatherJSON) => {
				this.dispatch({ type: 'GET_WEATHER', payload: weatherJSON });
			})
			.catch((rej) => {
				console.warn(rej + ' https://yandex.ru/dev/weather/doc/dg/concepts/errors-docpage/');
				alert('API Яндекс.Погоды не доступен https://yandex.ru/dev/weather/doc/dg/concepts/errors-docpage/ ' + rej);
			});
	}

	getTasks() {
		fetch('_')
			.then((response) => {
				return response.json();
			})
			.then((tasksJSON) => {
				this.dispatch({ type: 'GET_TASKS', payload: tasksJSON });
			})
			.catch((rej) => {
				console.warn(rej);
			});
	}
}
