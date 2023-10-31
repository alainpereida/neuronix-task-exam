import { createStoreHook } from 'react-redux'

const initialState = {
    showDrawer: false,
    auth: '',
}

const changeState = (state = initialState, { type, ...rest }) => {
    switch (type) {
        case 'set':
            return {...state, ...rest }
        case 'clear':
            return {...initialState}
        default:
            return state
    }
}

const store = createStoreHook(
    changeState,
    window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()
)

export default store
