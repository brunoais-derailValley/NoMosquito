import sys
from functools import partial
from pathlib import Path

printe = partial(print, file=sys.stderr)

project_dir = Path(__file__).parent.parent.absolute()

derail_valley = project_dir / 'Derail Valley'

if not derail_valley.is_symlink() or not derail_valley.is_dir():
	printe(f"Expecting to find a symlink to Derail Valley directory at: {derail_valley}\n"
		   f"but something else or nothing was found.")
	exit(2)

dv_mods_dir = project_dir / 'Derail Valley' / 'Mods'
