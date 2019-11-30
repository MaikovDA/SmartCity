const initialState = {
	temperature: -15
};

export default function weatherRreducer(state = initialState, action) {
	switch (action.type) {
		case 'GET_WEATHER':
			return {...action.payload};
		default:
			return state;
	}
};
