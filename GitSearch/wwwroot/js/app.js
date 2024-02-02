document.addEventListener('alpine:init', () => {
    Alpine.data('app', () => ({
        init() {
            console.log('app init')
        }
    }))
})