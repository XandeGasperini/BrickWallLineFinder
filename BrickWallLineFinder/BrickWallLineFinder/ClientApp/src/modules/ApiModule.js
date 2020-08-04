
export async function postBrickWall(json) {
    const response = await fetch('brickwall', {
        method: 'post',
        headers: new Headers({
            'Content-Type': 'application/json'
        }),
        body: JSON.stringify(json)
    });
    const data = await response.json();
    return data
}

export async function getBrickWall(json) {
    const params = json;
    const urlParams = new URLSearchParams(Object.entries(params));

    const response = await fetch('brickwall?' + urlParams, {
        method: 'get'
    });
    const data = await response.json();
    return data
}

export async function getAnalysis(json) {
    const params = json;
    const urlParams = new URLSearchParams(Object.entries(params));

    const response = await fetch('Analysis?' + urlParams, {
        method: 'get'
    });
    const data = await response.json();
    return data
}