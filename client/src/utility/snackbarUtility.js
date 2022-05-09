export const handleSnackbarOpen = (message, setSnackbarState) => {
    setSnackbarState({'state': true, 'message': message});
}

export const handleSnackbarClose = (setSnackbarState) => (event, reason) => {
    if (reason === 'clickaway') {
        return;
    }
    setSnackbarState({'state': false, 'message': 'Closing...'});
}