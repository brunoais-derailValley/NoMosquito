#!/bin/bash

echoerr () {
	>&2 echo "$@"
}

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" >/dev/null 2>&1 && pwd )"

DERAIL_VALLEY="$DIR/Derail Valley"

if ! [[ -L "$DERAIL_VALLEY" && -d "$DERAIL_VALLEY" ]]; then
	echoerr "Expecting to find a symlink to Derail Valley directory at: $DERAIL_VALLEY"
	echoerr "but something else or nothing was found. Maybe this ls command will help:"

	( set -x; ls -la "$DERAIL_VALLEY")
	exit 2
fi

#dotnet build -c Release

#MOD_DIR="$DERAIL_VALLEY/Mods/NoMosquito"
MOD_DIR="$DERAIL_VALLEY/Mods"
pwsh "$DIR"/package.ps1 -NoArchive -OutputDirectory "$MOD_DIR"
