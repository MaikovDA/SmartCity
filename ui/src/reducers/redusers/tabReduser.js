const initialState = 'manager';

export default function mapReducer(state = initialState, action) {
	switch (action.type) {
		case 'SET_TAB':
			return action.payload;
		default:
			return state
	}
};
