document.addEventListener('alpine:init', () => {
    Alpine.data('home', () => ({
        hello: 'here is going to be a home page',
        async init() {
            console.log('Init in calculator');
        },
    }))
})