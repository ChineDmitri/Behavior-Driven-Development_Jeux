const { createApp, ref, unref, onMounted, computed } = Vue

const BASE_URL = "."

createApp(
    {
        setup() {
            const isStarted = ref(false);
            const loading = ref(false);
            const player1 = ref({ firstname: '', lastname: '' });
            const player2 = ref({ firstname: '', lastname: '' });
            const score = ref(null);

            const setActuel = computed(() => unref(dataApp.value.setActuel));

            const jouers = [
                {
                    id: undefined,
                    nom: undefined,
                    prenom: undefined,
                    indexJeuScore: undefined,
                    scoreTieBreak: undefined
                },
                {
                    id: undefined,
                    nom: undefined,
                    prenom: undefined,
                    indexJeuScore: undefined,
                    scoreTieBreak: undefined
                }
            ]
            const dataApp = ref(null);

            // Initialize data when the app starts
            onMounted(async () => {
                loading.value = true;
                try {
                    fetch(BASE_URL + '/api/getData')
                        .then(response => {
                            if (!response.ok) {
                                throw new Error(`HTTP error! status: ${response.status}`);
                            }

                            return response.json();
                        })
                        .then(data => {
                            console.log("ON MOUNTED", data)
                            dataApp.value = data;
                            console.log("ON MOUNTED THIS.DATA", this.dataApp)
                            isStarted.value = true;
                        })
                        .catch(e => {
                            console.log("ERROR ON MOUNTED", e)
                        });

                } catch (error) {
                    console.error(error);
                }
                loading.value = false;
            });


            function createMatch() {
                const data = {
                    player1: {
                        id: 1,
                        lastname: player1.value.lastname,
                        firstname: player1.value.firstname,
                    },
                    player2: {
                        id: 2,
                        lastname: player2.value.lastname,
                        firstname: player2.value.firstname,
                    }
                };
                console.log("payload", data)

                fetch(BASE_URL + '/api/createMatch', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(data)
                })
                    .then(response => {
                        return response.json()
                    })
                    .then(data => {
                        console.log(data)
                        dataApp.value = data;
                        console.log("THIS.DATA", this.dataApp)
                        isStarted.value = true;
                    })
                    .catch(error => console.error(error));
            }


            function winPoint(id) {
                fetch(BASE_URL + '/api/winPoint/' + id)
                    .then(response => {
                        console.log(response)
                        return response.json()
                    })
                    .then(data => {
                        console.log(data)
                        dataApp.value = data;
                        console.log("THIS.DATA", dataApp._rawValue)
                        console.log("setsCompleted", setsCompleted())
                    })
                    .catch(error => console.error(error));
            }

            function setsCompleted() {
                if (dataApp._rawValue != null) {
                    const setsWithVainqueur = dataApp._rawValue.sets.filter(s => {
                        return s.vainqueur !== null;
                    })

                    return setsWithVainqueur
                }

                return []
            }

            function setsWin(id, set) {
                if (set) {
                    const gamesWithVainqueur = set.filter(s => {
                        if (s.vainqueur)
                            return s.vainqueur.id == id;
                    })

                    return gamesWithVainqueur.length;
                }
            }

            function gamesWin(id, set, idxSet) {
                if (set.length == 0) return 0

                if (set[idxSet].jeux) {
                    const gamesWithVainqueur = set[idxSet].jeux.filter(g => {
                        if (g.vainqueur)
                            return g.vainqueur.id == id;
                    })
                    return gamesWithVainqueur.length;
                }
  
                return 0
            }


            return {
                dataApp,
                setActuel,
                loading,
                isStarted,
                player1,
                player2,
                createMatch,
                winPoint,
                setsCompleted,
                gamesWin,
                setsWin
            }
        }
    }).mount('#app')
