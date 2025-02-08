let classes = null;

export async function getClasses() {
    if (classes === null) {
        const response = await fetch(import.meta.env.VITE_API_URL + '/api/public/classes');
        classes = await response.json();
    }
    return classes;
}