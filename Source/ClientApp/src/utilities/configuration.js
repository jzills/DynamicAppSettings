const getConfiguration = async type => {
    const response = await fetch(`configuration/${type}`)
    if (response.ok) {
        return response.json()
    } else {
        console.error(`${response.status}: ${response.statusText}`)
    }
}

const getConfigurationTypes = async () => {
    const response = await fetch(`configuration/types`)
    if (response.ok) {
        return response.json()
    } else {
        console.error(`${response.status}: ${response.statusText}`)
    }
}

export { getConfiguration, getConfigurationTypes }