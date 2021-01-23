//updates a component's value based on the target's name and if there's a postSetStateFunction passed
//sends that as the callback for setState
export function handleInputChange(event, component, postSetStateFunction) {
        const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        //uses the name of the element to determine what state value to update
        const name = target.name;

        component.setState({
            [name]: value
        }, postSetStateFunction);
    }

export function callGet(uri) {
    return fetch(process.env.REACT_APP_API_URL + uri, {
        method: 'GET'
    });
}

export function callMultipartPost(uri, data) {
    return fetch(process.env.REACT_APP_API_URL + uri, {
        method: 'POST',
        body: data
    });
}

export function callPost(uri, data) {
    return fetch(process.env.REACT_APP_API_URL + uri, {
        method: 'POST',
        body: JSON.stringify(data)
    });
}

export function callPut(uri, data) {
    return fetch(process.env.REACT_APP_API_URL + uri, {
        method: 'PUT',
        body: JSON.stringify(data)
    });
}

export function callDelete(uri) {
    return fetch(process.env.REACT_APP_API_URL + uri, {
        method: 'DELETE'
    });
}