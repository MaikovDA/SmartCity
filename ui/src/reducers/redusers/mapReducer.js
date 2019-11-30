const initialState = {
  center: [55.76, 37.64],
  zoom: 9,
  controls: ['zoomControl', 'typeSelector', 'fullscreenControl'],
};

export default function mapReducer(state = initialState, action) {
	switch (action.type) {
		case 'SET_STATE':
			return {...state, ...action.payload};
		default:
			return state;
	}
};
